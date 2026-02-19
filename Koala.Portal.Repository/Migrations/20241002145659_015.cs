using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _015 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "TransactionItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "TransactionItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "TransactionItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "TransactionItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpDate",
                table: "Applications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsMultiModuleApplication",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPackageApplication",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LisansFirmId",
                table: "ApplicationLicences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModulesCryptedJson",
                table: "ApplicationLicences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationFirms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirmId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFirms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFirms_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationFirms_CrmFirm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "CrmFirm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationModules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desctiption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationModules_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLicences_LisansFirmId",
                table: "ApplicationLicences",
                column: "LisansFirmId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFirms_ApplicationId",
                table: "ApplicationFirms",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFirms_FirmId",
                table: "ApplicationFirms",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationModules_ApplicationId",
                table: "ApplicationModules",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationLicences_CrmFirm_LisansFirmId",
                table: "ApplicationLicences",
                column: "LisansFirmId",
                principalTable: "CrmFirm",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationLicences_CrmFirm_LisansFirmId",
                table: "ApplicationLicences");

            migrationBuilder.DropTable(
                name: "ApplicationFirms");

            migrationBuilder.DropTable(
                name: "ApplicationModules");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationLicences_LisansFirmId",
                table: "ApplicationLicences");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "TransactionItem");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "TransactionItem");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "TransactionItem");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "TransactionItem");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "IsMultiModuleApplication",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsPackageApplication",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "LisansFirmId",
                table: "ApplicationLicences");

            migrationBuilder.DropColumn(
                name: "ModulesCryptedJson",
                table: "ApplicationLicences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpDate",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
