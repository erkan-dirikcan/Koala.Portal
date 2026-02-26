using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCrmFirmContactForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLine_CrmFirmContact_LineFirmOfficialId",
                table: "ProjectLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWork_CrmFirmContact_DeliveredPersonOid",
                table: "ProjectLineWork");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWork_CrmFirmContact_LineFirmOfficialId",
                table: "ProjectLineWork");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLineWork_DeliveredPersonOid",
                table: "ProjectLineWork");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLineWork_LineFirmOfficialId",
                table: "ProjectLineWork");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLine_LineFirmOfficialId",
                table: "ProjectLine");

            migrationBuilder.AlterColumn<string>(
                name: "LineFirmOfficialId",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveredPersonOid",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LineFirmOfficialId",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppNotification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNotification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNotification_UserId",
                table: "AppNotification",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppNotification");

            migrationBuilder.AlterColumn<string>(
                name: "LineFirmOfficialId",
                table: "ProjectLineWork",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveredPersonOid",
                table: "ProjectLineWork",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LineFirmOfficialId",
                table: "ProjectLine",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWork_DeliveredPersonOid",
                table: "ProjectLineWork",
                column: "DeliveredPersonOid");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWork_LineFirmOfficialId",
                table: "ProjectLineWork",
                column: "LineFirmOfficialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLine_LineFirmOfficialId",
                table: "ProjectLine",
                column: "LineFirmOfficialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLine_CrmFirmContact_LineFirmOfficialId",
                table: "ProjectLine",
                column: "LineFirmOfficialId",
                principalTable: "CrmFirmContact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineWork_CrmFirmContact_DeliveredPersonOid",
                table: "ProjectLineWork",
                column: "DeliveredPersonOid",
                principalTable: "CrmFirmContact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineWork_CrmFirmContact_LineFirmOfficialId",
                table: "ProjectLineWork",
                column: "LineFirmOfficialId",
                principalTable: "CrmFirmContact",
                principalColumn: "Id");
        }
    }
}
