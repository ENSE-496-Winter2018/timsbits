using Microsoft.EntityFrameworkCore.Migrations;

namespace eideas.Migrations
{
    public partial class model3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentUpDoot_AspNetUsers_EIdeasUserId",
                table: "CommentUpDoot");

            migrationBuilder.DropForeignKey(
                name: "FK_IdeaUpDoot_AspNetUsers_EIdeasUserId",
                table: "IdeaUpDoot");

            migrationBuilder.RenameColumn(
                name: "EIdeasUserId",
                table: "IdeaUpDoot",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EIdeasUserId",
                table: "CommentUpDoot",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUpDoot_AspNetUsers_Id",
                table: "CommentUpDoot",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaUpDoot_AspNetUsers_Id",
                table: "IdeaUpDoot",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentUpDoot_AspNetUsers_Id",
                table: "CommentUpDoot");

            migrationBuilder.DropForeignKey(
                name: "FK_IdeaUpDoot_AspNetUsers_Id",
                table: "IdeaUpDoot");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "IdeaUpDoot",
                newName: "EIdeasUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommentUpDoot",
                newName: "EIdeasUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUpDoot_AspNetUsers_EIdeasUserId",
                table: "CommentUpDoot",
                column: "EIdeasUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaUpDoot_AspNetUsers_EIdeasUserId",
                table: "IdeaUpDoot",
                column: "EIdeasUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
