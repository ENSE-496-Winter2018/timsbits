using Microsoft.EntityFrameworkCore.Migrations;

namespace eideas.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EIdeasUserId",
                table: "Ideas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_EIdeasUserId",
                table: "Ideas",
                column: "EIdeasUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_AspNetUsers_EIdeasUserId",
                table: "Ideas",
                column: "EIdeasUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_AspNetUsers_EIdeasUserId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_EIdeasUserId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "EIdeasUserId",
                table: "Ideas");
        }
    }
}
