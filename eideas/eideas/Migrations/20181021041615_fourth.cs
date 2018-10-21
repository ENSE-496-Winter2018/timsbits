using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eideas.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdeaComments",
                columns: table => new
                {
                    IdeaCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    EIdeasUserId = table.Column<string>(nullable: true),
                    IdeaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaComments", x => x.IdeaCommentId);
                    table.ForeignKey(
                        name: "FK_IdeaComments_AspNetUsers_EIdeasUserId",
                        column: x => x.EIdeasUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdeaComments_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdeaSubscriptions",
                columns: table => new
                {
                    IdeaId = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaSubscriptions", x => new { x.Id, x.IdeaId });
                    table.ForeignKey(
                        name: "FK_IdeaSubscriptions_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaSubscriptions_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdeaUpDoot",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdeaId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaUpDoot", x => new { x.Id, x.IdeaId });
                    table.ForeignKey(
                        name: "FK_IdeaUpDoot_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaUpDoot_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentUpDoots",
                columns: table => new
                {
                    IdeaCommentId = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentUpDoots", x => new { x.Id, x.IdeaCommentId });
                    table.ForeignKey(
                        name: "FK_CommentUpDoots_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentUpDoots_IdeaComments_IdeaCommentId",
                        column: x => x.IdeaCommentId,
                        principalTable: "IdeaComments",
                        principalColumn: "IdeaCommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentUpDoots_IdeaCommentId",
                table: "CommentUpDoots",
                column: "IdeaCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaComments_EIdeasUserId",
                table: "IdeaComments",
                column: "EIdeasUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaComments_IdeaId",
                table: "IdeaComments",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaSubscriptions_IdeaId",
                table: "IdeaSubscriptions",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaUpDoot_IdeaId",
                table: "IdeaUpDoot",
                column: "IdeaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentUpDoots");

            migrationBuilder.DropTable(
                name: "IdeaSubscriptions");

            migrationBuilder.DropTable(
                name: "IdeaUpDoot");

            migrationBuilder.DropTable(
                name: "IdeaComments");
        }
    }
}
