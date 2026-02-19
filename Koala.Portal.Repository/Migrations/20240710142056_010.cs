using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacationHistory_VacationRequest_VacationId",
                table: "VacationHistory");

            migrationBuilder.AlterColumn<string>(
                name: "VacationId",
                table: "VacationHistory",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdded",
                table: "VacationHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReleatedUserId",
                table: "VacationHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationHistory_AspNetUsers_VacationId",
                table: "VacationHistory",
                column: "VacationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VacationHistory_VacationRequest_VacationId",
                table: "VacationHistory",
                column: "VacationId",
                principalTable: "VacationRequest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacationHistory_AspNetUsers_VacationId",
                table: "VacationHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_VacationHistory_VacationRequest_VacationId",
                table: "VacationHistory");

            migrationBuilder.DropColumn(
                name: "IsAdded",
                table: "VacationHistory");

            migrationBuilder.DropColumn(
                name: "ReleatedUserId",
                table: "VacationHistory");

            migrationBuilder.AlterColumn<string>(
                name: "VacationId",
                table: "VacationHistory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VacationHistory_VacationRequest_VacationId",
                table: "VacationHistory",
                column: "VacationId",
                principalTable: "VacationRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
