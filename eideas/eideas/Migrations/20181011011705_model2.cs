using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eideas.Migrations
{
    public partial class model2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Organization",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDivisionDivisionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserUnitUnitId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivisionName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                });

            migrationBuilder.CreateTable(
                name: "Idea",
                columns: table => new
                {
                    IdeaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdeaName = table.Column<string>(nullable: true),
                    IdeaContent = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idea", x => x.IdeaId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    TeamManagerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_AspNetUsers_TeamManagerId",
                        column: x => x.TeamManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnitName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "IdeaComment",
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
                    table.PrimaryKey("PK_IdeaComment", x => x.IdeaCommentId);
                    table.ForeignKey(
                        name: "FK_IdeaComment_AspNetUsers_EIdeasUserId",
                        column: x => x.EIdeasUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdeaComment_Idea_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Idea",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdeaSubscription",
                columns: table => new
                {
                    IdeaId = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaSubscription", x => new { x.Id, x.IdeaId });
                    table.ForeignKey(
                        name: "FK_IdeaSubscription_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaSubscription_Idea_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Idea",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdeaUpDoot",
                columns: table => new
                {
                    EIdeasUserId = table.Column<string>(nullable: false),
                    IdeaId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaUpDoot", x => new { x.EIdeasUserId, x.IdeaId });
                    table.ForeignKey(
                        name: "FK_IdeaUpDoot_AspNetUsers_EIdeasUserId",
                        column: x => x.EIdeasUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaUpDoot_Idea_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Idea",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentUpDoot",
                columns: table => new
                {
                    IdeaCommentId = table.Column<int>(nullable: false),
                    EIdeasUserId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentUpDoot", x => new { x.EIdeasUserId, x.IdeaCommentId });
                    table.ForeignKey(
                        name: "FK_CommentUpDoot_AspNetUsers_EIdeasUserId",
                        column: x => x.EIdeasUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentUpDoot_IdeaComment_IdeaCommentId",
                        column: x => x.IdeaCommentId,
                        principalTable: "IdeaComment",
                        principalColumn: "IdeaCommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamId",
                table: "AspNetUsers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserDivisionDivisionId",
                table: "AspNetUsers",
                column: "UserDivisionDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserUnitUnitId",
                table: "AspNetUsers",
                column: "UserUnitUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentUpDoot_IdeaCommentId",
                table: "CommentUpDoot",
                column: "IdeaCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaComment_EIdeasUserId",
                table: "IdeaComment",
                column: "EIdeasUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaComment_IdeaId",
                table: "IdeaComment",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaSubscription_IdeaId",
                table: "IdeaSubscription",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaUpDoot_IdeaId",
                table: "IdeaUpDoot",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamManagerId",
                table: "Team",
                column: "TeamManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Team_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Division_UserDivisionDivisionId",
                table: "AspNetUsers",
                column: "UserDivisionDivisionId",
                principalTable: "Division",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Unit_UserUnitUnitId",
                table: "AspNetUsers",
                column: "UserUnitUnitId",
                principalTable: "Unit",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Team_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Division_UserDivisionDivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Unit_UserUnitUnitId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CommentUpDoot");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "IdeaSubscription");

            migrationBuilder.DropTable(
                name: "IdeaUpDoot");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "IdeaComment");

            migrationBuilder.DropTable(
                name: "Idea");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserDivisionDivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserUnitUnitId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserDivisionDivisionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserUnitUnitId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
