using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SyncUpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_CrmFirmContact_FirmPersonId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_CrmFirm_FirmId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_FirmId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_FirmPersonId",
                table: "Project");

            migrationBuilder.AlterColumn<string>(
                name: "FirmPersonId",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirmId",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FirmPersonId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirmId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FirmId",
                table: "Project",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FirmPersonId",
                table: "Project",
                column: "FirmPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_CrmFirmContact_FirmPersonId",
                table: "Project",
                column: "FirmPersonId",
                principalTable: "CrmFirmContact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_CrmFirm_FirmId",
                table: "Project",
                column: "FirmId",
                principalTable: "CrmFirm",
                principalColumn: "Id");
        }
    }
}
