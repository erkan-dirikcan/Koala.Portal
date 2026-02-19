using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmFirmContact_CrmFirm_FirmId",
                table: "CrmFirmContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_CrmFirmContact_FirmPersonId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLine_Project_ProjectId",
                table: "ProjectLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineNote_ProjectLine_ProjectLineId",
                table: "ProjectLineNote");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWork_ProjectLine_LineId",
                table: "ProjectLineWork");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWorkSupports_ProjectLineWork_ProjectLinetWorkId",
                table: "ProjectLineWorkSupports");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPerson_AspNetUsers_UserId",
                table: "ProjectPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPerson_ProjectLine_ProjectLineId",
                table: "ProjectPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPerson_Project_ProjectId",
                table: "ProjectPerson");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPerson_ProjectId",
                table: "ProjectPerson");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPerson_ProjectLineId",
                table: "ProjectPerson");

            migrationBuilder.DropColumn(
                name: "DeliveredPerson",
                table: "ProjectLineWork");

            migrationBuilder.RenameColumn(
                name: "RowOrdwer",
                table: "ProjectLineWork",
                newName: "RowOrder");

            migrationBuilder.AddColumn<int>(
                name: "DropFromAnnualVaccationAmount",
                table: "VacationRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProjectPerson",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectLineId",
                table: "ProjectPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectPerson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "TimeSpend",
                table: "ProjectLineWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReportDescription",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveredPersonOid",
                table: "ProjectLineWork",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CancelDescription",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LineFirmOfficialId",
                table: "ProjectLineWork",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProjectLineNote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReportNote",
                table: "ProjectLineNote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProjectLineNote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTime",
                table: "ProjectLine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RowOrdwer",
                table: "ProjectLine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReportDescription",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CancelDescription",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LineFirmOfficialId",
                table: "ProjectLine",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineOfficialId",
                table: "ProjectLine",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectFiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectManagerId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirmPersonId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CancelDescription",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWork_DeliveredPersonOid",
                table: "ProjectLineWork",
                column: "DeliveredPersonOid");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWork_LineFirmOfficialId",
                table: "ProjectLineWork",
                column: "LineFirmOfficialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWork_RowOrder",
                table: "ProjectLineWork",
                column: "RowOrder");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLine_LineFirmOfficialId",
                table: "ProjectLine",
                column: "LineFirmOfficialId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLine_LineOfficialId",
                table: "ProjectLine",
                column: "LineOfficialId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmFirmContact_CrmFirm_FirmId",
                table: "CrmFirmContact",
                column: "FirmId",
                principalTable: "CrmFirm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_CrmFirmContact_FirmPersonId",
                table: "Project",
                column: "FirmPersonId",
                principalTable: "CrmFirmContact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLine_AspNetUsers_LineOfficialId",
                table: "ProjectLine",
                column: "LineOfficialId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLine_CrmFirmContact_LineFirmOfficialId",
                table: "ProjectLine",
                column: "LineFirmOfficialId",
                principalTable: "CrmFirmContact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLine_Project_ProjectId",
                table: "ProjectLine",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineNote_ProjectLine_ProjectLineId",
                table: "ProjectLineNote",
                column: "ProjectLineId",
                principalTable: "ProjectLine",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineWork_ProjectLine_LineId",
                table: "ProjectLineWork",
                column: "LineId",
                principalTable: "ProjectLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineWorkSupports_ProjectLineWork_ProjectLinetWorkId",
                table: "ProjectLineWorkSupports",
                column: "ProjectLinetWorkId",
                principalTable: "ProjectLineWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPerson_AspNetUsers_UserId",
                table: "ProjectPerson",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmFirmContact_CrmFirm_FirmId",
                table: "CrmFirmContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_CrmFirmContact_FirmPersonId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLine_AspNetUsers_LineOfficialId",
                table: "ProjectLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLine_CrmFirmContact_LineFirmOfficialId",
                table: "ProjectLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLine_Project_ProjectId",
                table: "ProjectLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineNote_ProjectLine_ProjectLineId",
                table: "ProjectLineNote");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWork_CrmFirmContact_DeliveredPersonOid",
                table: "ProjectLineWork");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWork_CrmFirmContact_LineFirmOfficialId",
                table: "ProjectLineWork");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWork_ProjectLine_LineId",
                table: "ProjectLineWork");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLineWorkSupports_ProjectLineWork_ProjectLinetWorkId",
                table: "ProjectLineWorkSupports");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPerson_AspNetUsers_UserId",
                table: "ProjectPerson");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLineWork_DeliveredPersonOid",
                table: "ProjectLineWork");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLineWork_LineFirmOfficialId",
                table: "ProjectLineWork");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLineWork_RowOrder",
                table: "ProjectLineWork");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLine_LineFirmOfficialId",
                table: "ProjectLine");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLine_LineOfficialId",
                table: "ProjectLine");

            migrationBuilder.DropColumn(
                name: "DropFromAnnualVaccationAmount",
                table: "VacationRequest");

            migrationBuilder.DropColumn(
                name: "LineFirmOfficialId",
                table: "ProjectLineWork");

            migrationBuilder.DropColumn(
                name: "LineFirmOfficialId",
                table: "ProjectLine");

            migrationBuilder.DropColumn(
                name: "LineOfficialId",
                table: "ProjectLine");

            migrationBuilder.RenameColumn(
                name: "RowOrder",
                table: "ProjectLineWork",
                newName: "RowOrdwer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProjectPerson",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectLineId",
                table: "ProjectPerson",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectPerson",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TimeSpend",
                table: "ProjectLineWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportDescription",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveredPersonOid",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancelDescription",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveredPerson",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProjectLineNote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportNote",
                table: "ProjectLineNote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ProjectLineNote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTime",
                table: "ProjectLine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RowOrdwer",
                table: "ProjectLine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportDescription",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancelDescription",
                table: "ProjectLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProjectFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectManagerId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirmPersonId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancelDescription",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_ProjectId",
                table: "ProjectPerson",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPerson_ProjectLineId",
                table: "ProjectPerson",
                column: "ProjectLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmFirmContact_CrmFirm_FirmId",
                table: "CrmFirmContact",
                column: "FirmId",
                principalTable: "CrmFirm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_CrmFirmContact_FirmPersonId",
                table: "Project",
                column: "FirmPersonId",
                principalTable: "CrmFirmContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLine_Project_ProjectId",
                table: "ProjectLine",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineNote_ProjectLine_ProjectLineId",
                table: "ProjectLineNote",
                column: "ProjectLineId",
                principalTable: "ProjectLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineWork_ProjectLine_LineId",
                table: "ProjectLineWork",
                column: "LineId",
                principalTable: "ProjectLine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLineWorkSupports_ProjectLineWork_ProjectLinetWorkId",
                table: "ProjectLineWorkSupports",
                column: "ProjectLinetWorkId",
                principalTable: "ProjectLineWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPerson_AspNetUsers_UserId",
                table: "ProjectPerson",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPerson_ProjectLine_ProjectLineId",
                table: "ProjectPerson",
                column: "ProjectLineId",
                principalTable: "ProjectLine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPerson_Project_ProjectId",
                table: "ProjectPerson",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
