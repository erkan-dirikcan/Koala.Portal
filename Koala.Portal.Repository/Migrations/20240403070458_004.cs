using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationLicences_AspNetUsers_ApprovedByUserId",
                table: "ApplicationLicences");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByUserId",
                table: "ApplicationLicences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "ApplicationLicences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationLicences_AspNetUsers_ApprovedByUserId",
                table: "ApplicationLicences",
                column: "ApprovedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationLicences_AspNetUsers_ApprovedByUserId",
                table: "ApplicationLicences");

            migrationBuilder.DropColumn(
                name: "PcName",
                table: "ApplicationLicences");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedByUserId",
                table: "ApplicationLicences",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationLicences_AspNetUsers_ApprovedByUserId",
                table: "ApplicationLicences",
                column: "ApprovedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
