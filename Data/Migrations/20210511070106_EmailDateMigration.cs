using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EmailDateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "EmailQueue");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "EmailQueue");

            migrationBuilder.DropColumn(
                name: "SentTime",
                table: "EmailQueue");

            migrationBuilder.DropColumn(
                name: "When",
                table: "EmailQueue");

            migrationBuilder.CreateTable(
                name: "EmailDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    EmailQueueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSent = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false, defaultValue: 10),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailDates_EmailQueue_EmailQueueId",
                        column: x => x.EmailQueueId,
                        principalTable: "EmailQueue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_EmailDates_EmailQueueId",
                table: "EmailDates",
                column: "EmailQueueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailDates");

            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "EmailQueue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "EmailQueue",
                type: "int",
                nullable: false,
                defaultValue: 10);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentTime",
                table: "EmailQueue",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "When",
                table: "EmailQueue",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueue_EmailProviderId",
                table: "EmailQueue",
                column: "EmailProviderId",
                unique: true);
        }
    }
}
