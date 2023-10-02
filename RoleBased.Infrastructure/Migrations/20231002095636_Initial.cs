using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBased.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginDB",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDB", x => x.RegNo);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.RegNo);
                });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "RegNo", "Created", "CreatedBy", "DOB", "Email", "LastModified", "LastModifiedBy", "Name", "PhoneNumber", "Status" },
                values: new object[] { "1", new DateTimeOffset(new DateTime(2023, 10, 2, 15, 56, 36, 481, DateTimeKind.Unspecified).AddTicks(1964), new TimeSpan(0, 6, 0, 0, 0)), "1", new DateTimeOffset(new DateTime(2023, 10, 2, 15, 56, 36, 481, DateTimeKind.Unspecified).AddTicks(1937), new TimeSpan(0, 6, 0, 0, 0)), "rahat@gmail.com", new DateTimeOffset(new DateTime(2023, 10, 2, 15, 56, 36, 481, DateTimeKind.Unspecified).AddTicks(1966), new TimeSpan(0, 6, 0, 0, 0)), null, "Rahat Ahmed Tanjim", "0198xxxxxx", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginDB");

            migrationBuilder.DropTable(
                name: "StudentInfo");
        }
    }
}
