using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _017 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ParentId sütununu ekle (nullable)
            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "HelpDeskCatogory",
                type: "nvarchar(450)",
                nullable: true);

            // Index ekle
            migrationBuilder.CreateIndex(
                name: "IX_HelpDeskCatogory_ParentId",
                table: "HelpDeskCatogory",
                column: "ParentId");

            // Foreign Key ekle
            migrationBuilder.AddForeignKey(
                name: "FK_HelpDeskCatogory_HelpDeskCatogory_ParentId",
                table: "HelpDeskCatogory",
                column: "ParentId",
                principalTable: "HelpDeskCatogory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpDeskCatogory_HelpDeskCatogory_ParentId",
                table: "HelpDeskCatogory");

            migrationBuilder.DropIndex(
                name: "IX_HelpDeskCatogory_ParentId",
                table: "HelpDeskCatogory");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "HelpDeskCatogory");
        }
    }
}
