
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CallCenterAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CallFileProcessor
{
    public interface ICallRecordProcessor
    {
        Task ProcessFileAsync(string sourceFilePath);
    }

    public class CallRecordProcessor : ICallRecordProcessor
    {
        private readonly string destinationFolderPath;
        private readonly ICallRecordConverter callRecordConverter;
        private readonly string connectionString;

        public CallRecordProcessor(ICallRecordConverter callRecordConverter, IConfiguration configuration)
        {
            this.callRecordConverter = callRecordConverter ?? throw new ArgumentNullException(nameof(callRecordConverter));
            connectionString = configuration.GetConnectionString("DefaultConnection");
            destinationFolderPath = configuration.GetValue<string>("DestinationFolderPath");
        }

        public async Task ProcessFileAsync(string sourceFilePath)
        {
            try
            {
                using (var dbContext = CreateDbContext())
                {
                    string[] lines = await File.ReadAllLinesAsync(sourceFilePath);

                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');

                        if (callRecordConverter.IsValidRecord(values))
                        {
                            CallRecord callRecord = callRecordConverter.ConvertToCallRecord(values);
                            dbContext.CallRecords.Add(callRecord);
                        }
                    }

                    await dbContext.SaveChangesAsync();
                }

                MoveFileToDestination(sourceFilePath);
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir.
            }
        }

        private CallDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CallDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CallDbContext(optionsBuilder.Options);
        }

        private void MoveFileToDestination(string sourceFilePath)
        {
            string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));
            File.Move(sourceFilePath, destinationFilePath);
        }
    }
}
