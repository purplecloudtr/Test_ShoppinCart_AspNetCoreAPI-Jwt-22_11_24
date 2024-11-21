using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreAPI_Jwt_Bearer.Migrations
{
    /// <inheritdoc />
    public partial class initialandseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BeginDate", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 18, 1, 34, 18, 362, DateTimeKind.Local).AddTicks(2725), "aliucar@gmail.com", "Ali", "Uçar", "543 345 66 77" },
                    { 2, new DateTime(2024, 11, 18, 1, 34, 18, 362, DateTimeKind.Local).AddTicks(2741), "oyakosar@gmail.com", "Oya", "Koşar", "533 345 22 44" },
                    { 3, new DateTime(2024, 11, 18, 1, 34, 18, 362, DateTimeKind.Local).AddTicks(2743), "zeynep@gmail.com", "Zeynep", "Sever", "532 145 33 77" },
                    { 4, new DateTime(2024, 11, 18, 1, 34, 18, 362, DateTimeKind.Local).AddTicks(2744), "hasan@gmail.com", "Hasan", "Kaya", "545 345 11 22" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
