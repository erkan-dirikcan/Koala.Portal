using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedCrmDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserCrmDepartment");

            migrationBuilder.DropTable(
                name: "CrmDepartment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CrmDepartment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrmDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserCrmDepartment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmanId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserCrmDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserCrmDepartment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserCrmDepartment_CrmDepartment_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "CrmDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCrmDepartment_AppUserId",
                table: "AppUserCrmDepartment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserCrmDepartment_DepartmanId",
                table: "AppUserCrmDepartment",
                column: "DepartmanId");
        }
    }
}
