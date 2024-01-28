using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CallCenterAPI.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Internal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    External = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondInternal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallAnswered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeAnswered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonTerminated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToDn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DialNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonChanged = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalDn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallRecords");
        }
    }
}
