using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailProviders",
                keyColumn: "Id",
                keyValue: new Guid("e14df191-d909-4fc8-baab-7b47de64d88c"));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "EmailQueue",
                type: "int",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.InsertData(
                table: "EmailProviders",
                columns: new[] { "Id", "EnableSSL", "Host", "Password", "Port", "UserName" },
                values: new object[] { new Guid("7a208530-5902-4c1a-a81a-f2e9dc95ffa9"), true, "smtp.gmail.com", "", 587, "smtp.gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailProviders",
                keyColumn: "Id",
                keyValue: new Guid("7a208530-5902-4c1a-a81a-f2e9dc95ffa9"));

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "EmailQueue");

            migrationBuilder.InsertData(
                table: "EmailProviders",
                columns: new[] { "Id", "EnableSSL", "Host", "Password", "Port", "UserName" },
                values: new object[] { new Guid("e14df191-d909-4fc8-baab-7b47de64d88c"), true, "smtp.gmail.com", "", 587, "smtp.gmail.com" });
        }
    }
}
