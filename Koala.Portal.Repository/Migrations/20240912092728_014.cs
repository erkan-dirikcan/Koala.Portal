using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectLineWorkSupports");

            migrationBuilder.AddColumn<string>(
                name: "TransactionNumber",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReleatedSupportId",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleatedSupportOid",
                table: "ProjectLineWork",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionNumber",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ReleatedSupportId",
                table: "ProjectLineWork");

            migrationBuilder.DropColumn(
                name: "ReleatedSupportOid",
                table: "ProjectLineWork");

            migrationBuilder.CreateTable(
                name: "ProjectLineWorkSupports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectLinetWorkId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupportCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportOid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLineWorkSupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLineWorkSupports_ProjectLineWork_ProjectLinetWorkId",
                        column: x => x.ProjectLinetWorkId,
                        principalTable: "ProjectLineWork",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLineWorkSupports_ProjectLinetWorkId",
                table: "ProjectLineWorkSupports",
                column: "ProjectLinetWorkId");
        }
    }
}
