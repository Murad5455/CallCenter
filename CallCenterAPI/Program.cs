

using CallCenterAPI.Model;
using CallFileProcessor;
using CallFileProcessor.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<CallDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add your CallFileProcessor services here
builder.Services.AddScoped<IFileWatcher>(serviceProvider =>
{
    var sourceFolderPath = builder.Configuration["SourceFolderPath"];
    var callRecordProcessor = serviceProvider.GetRequiredService<ICallRecordProcessor>();
    return new FileWatcher(callRecordProcessor, sourceFolderPath);
});

builder.Services.AddScoped<ICallRecordProcessor, CallRecordProcessor>();
builder.Services.AddScoped<ICallRecordConverter, CallRecordConverter>();

var app = builder.Build();

// Create a scope for the services
using (var scope = app.Services.CreateScope())
{
    // Get an instance of CallDbContext
    var dbContext = scope.ServiceProvider.GetRequiredService<CallDbContext>();

    // Apply pending migrations if necessary
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();





