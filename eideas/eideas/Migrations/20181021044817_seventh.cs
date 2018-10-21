using Microsoft.EntityFrameworkCore.Migrations;

namespace eideas.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Units",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_DivisionId",
                table: "Units",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Divisions_DivisionId",
                table: "Units",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Divisions_DivisionId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_DivisionId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Units");
        }
    }
}
