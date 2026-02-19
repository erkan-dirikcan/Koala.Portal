using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VacationType",
                table: "VacationRequest");

            migrationBuilder.AddColumn<string>(
                name: "VacationTypeId",
                table: "VacationRequest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VacationTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequest_VacationTypeId",
                table: "VacationRequest",
                column: "VacationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacationRequest_VacationTypes_VacationTypeId",
                table: "VacationRequest",
                column: "VacationTypeId",
                principalTable: "VacationTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacationRequest_VacationTypes_VacationTypeId",
                table: "VacationRequest");

            migrationBuilder.DropTable(
                name: "VacationTypes");

            migrationBuilder.DropIndex(
                name: "IX_VacationRequest_VacationTypeId",
                table: "VacationRequest");

            migrationBuilder.DropColumn(
                name: "VacationTypeId",
                table: "VacationRequest");

            migrationBuilder.AddColumn<int>(
                name: "VacationType",
                table: "VacationRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
