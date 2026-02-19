using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Koala.Portal.Repository.Migrations
{
    /// <inheritdoc />
    public partial class _0016 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HelpDeskProblem_HelpDeskCatogory_CategoryId",
                table: "HelpDeskProblem");

            migrationBuilder.DropIndex(
                name: "IX_HelpDeskProblem_CategoryId",
                table: "HelpDeskProblem");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "HelpDeskProblem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "HelpDeskProblemCatogory",
                columns: table => new
                {
                    HelpDeskProblemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CatogoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpDeskProblemCatogory", x => new { x.CatogoryId, x.HelpDeskProblemId });
                    table.ForeignKey(
                        name: "FK_HelpDeskProblemCatogory_HelpDeskCatogory_CatogoryId",
                        column: x => x.CatogoryId,
                        principalTable: "HelpDeskCatogory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpDeskProblemCatogory_HelpDeskProblem_HelpDeskProblemId",
                        column: x => x.HelpDeskProblemId,
                        principalTable: "HelpDeskProblem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HelpDeskProblemCatogory_HelpDeskProblemId",
                table: "HelpDeskProblemCatogory",
                column: "HelpDeskProblemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpDeskProblemCatogory");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "HelpDeskProblem",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_HelpDeskProblem_CategoryId",
                table: "HelpDeskProblem",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HelpDeskProblem_HelpDeskCatogory_CategoryId",
                table: "HelpDeskProblem",
                column: "CategoryId",
                principalTable: "HelpDeskCatogory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
