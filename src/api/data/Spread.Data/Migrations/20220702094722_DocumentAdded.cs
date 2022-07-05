using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Data.Migrations
{
    public partial class DocumentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId",
                schema: "Media",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "Main",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_DocumentId",
                schema: "Media",
                table: "Posts",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Documents_DocumentId",
                schema: "Media",
                table: "Posts",
                column: "DocumentId",
                principalSchema: "Main",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Documents_DocumentId",
                schema: "Media",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Documents",
                schema: "Main");

            migrationBuilder.DropIndex(
                name: "IX_Posts_DocumentId",
                schema: "Media",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                schema: "Media",
                table: "Posts");
        }
    }
}
