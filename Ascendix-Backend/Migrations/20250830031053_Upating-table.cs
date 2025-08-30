using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Upatingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_certificates_AspNetUsers_userId1",
                table: "certificates");

            migrationBuilder.DropIndex(
                name: "IX_certificates_userId1",
                table: "certificates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dd327df-99ba-4d58-a991-07fb4959eb97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b133b37b-4c1c-4545-9c73-6291ff5012c5");

            migrationBuilder.DropColumn(
                name: "certificateURL",
                table: "userCourseProgresses");

            migrationBuilder.DropColumn(
                name: "actionType",
                table: "quests");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "quests");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "course");

            migrationBuilder.DropColumn(
                name: "nftTemplateId",
                table: "course");

            migrationBuilder.DropColumn(
                name: "issuedAt",
                table: "certificates");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "certificates");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "certificates");

            migrationBuilder.RenameColumn(
                name: "rewardAmount",
                table: "quests",
                newName: "tokenAllocation");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "library",
                newName: "slug");

            migrationBuilder.RenameColumn(
                name: "rewardAmount",
                table: "course",
                newName: "tokenAllocation");

            migrationBuilder.RenameColumn(
                name: "nftTokenId",
                table: "certificates",
                newName: "metaDataUrl");

            migrationBuilder.AddColumn<int>(
                name: "position",
                table: "modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "leaderBoards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rank = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    earnings = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaderBoards", x => x.id);
                    table.ForeignKey(
                        name: "FK_leaderBoards_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "moduleQuizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    moduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moduleQuizzes_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "modules",
                        principalColumn: "moduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userCertificates",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    certificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    issuedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCertificates", x => x.id);
                    table.ForeignKey(
                        name: "FK_userCertificates_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_userCertificates_certificates_certificateId",
                        column: x => x.certificateId,
                        principalTable: "certificates",
                        principalColumn: "certificateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizQuestions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    questionType = table.Column<int>(type: "int", nullable: false),
                    moduleQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                        column: x => x.moduleQuizId,
                        principalTable: "moduleQuizzes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "userQuizAttempts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    moduleQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userQuizAttempts", x => x.id);
                    table.ForeignKey(
                        name: "FK_userQuizAttempts_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_userQuizAttempts_moduleQuizzes_moduleQuizId",
                        column: x => x.moduleQuizId,
                        principalTable: "moduleQuizzes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "courseTags",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    courseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseTags", x => x.id);
                    table.ForeignKey(
                        name: "FK_courseTags_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_courseTags_course_courseId",
                        column: x => x.courseId,
                        principalTable: "course",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courseTags_tags_tagId",
                        column: x => x.tagId,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionOptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    optionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCorrect = table.Column<bool>(type: "bit", nullable: false),
                    quizQuestionsid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionOptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questionOptions_quizQuestions_quizQuestionsid",
                        column: x => x.quizQuestionsid,
                        principalTable: "quizQuestions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "userAnswers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attemptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    optionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    answerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    optionsid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAnswers", x => x.id);
                    table.ForeignKey(
                        name: "FK_userAnswers_questionOptions_optionsid",
                        column: x => x.optionsid,
                        principalTable: "questionOptions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_userAnswers_quizQuestions_questionId",
                        column: x => x.questionId,
                        principalTable: "quizQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userAnswers_userQuizAttempts_attemptId",
                        column: x => x.attemptId,
                        principalTable: "userQuizAttempts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5bc42881-83aa-473c-8481-2f655a8844e5", null, "User", "USER" },
                    { "acb6b0cf-b76d-47f8-a93d-c69994b6c733", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_courseTags_courseId",
                table: "courseTags",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_courseTags_tagId",
                table: "courseTags",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_courseTags_UserId",
                table: "courseTags",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_leaderBoards_userId",
                table: "leaderBoards",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_moduleQuizzes_moduleId",
                table: "moduleQuizzes",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_questionOptions_quizQuestionsid",
                table: "questionOptions",
                column: "quizQuestionsid");

            migrationBuilder.CreateIndex(
                name: "IX_quizQuestions_moduleQuizId",
                table: "quizQuestions",
                column: "moduleQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_userAnswers_attemptId",
                table: "userAnswers",
                column: "attemptId");

            migrationBuilder.CreateIndex(
                name: "IX_userAnswers_optionsid",
                table: "userAnswers",
                column: "optionsid");

            migrationBuilder.CreateIndex(
                name: "IX_userAnswers_questionId",
                table: "userAnswers",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_userCertificates_certificateId",
                table: "userCertificates",
                column: "certificateId");

            migrationBuilder.CreateIndex(
                name: "IX_userCertificates_userId",
                table: "userCertificates",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userQuizAttempts_moduleQuizId",
                table: "userQuizAttempts",
                column: "moduleQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_userQuizAttempts_userId",
                table: "userQuizAttempts",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseTags");

            migrationBuilder.DropTable(
                name: "leaderBoards");

            migrationBuilder.DropTable(
                name: "userAnswers");

            migrationBuilder.DropTable(
                name: "userCertificates");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "questionOptions");

            migrationBuilder.DropTable(
                name: "userQuizAttempts");

            migrationBuilder.DropTable(
                name: "quizQuestions");

            migrationBuilder.DropTable(
                name: "moduleQuizzes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc42881-83aa-473c-8481-2f655a8844e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acb6b0cf-b76d-47f8-a93d-c69994b6c733");

            migrationBuilder.DropColumn(
                name: "position",
                table: "modules");

            migrationBuilder.RenameColumn(
                name: "tokenAllocation",
                table: "quests",
                newName: "rewardAmount");

            migrationBuilder.RenameColumn(
                name: "slug",
                table: "library",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "tokenAllocation",
                table: "course",
                newName: "rewardAmount");

            migrationBuilder.RenameColumn(
                name: "metaDataUrl",
                table: "certificates",
                newName: "nftTokenId");

            migrationBuilder.AddColumn<string>(
                name: "certificateURL",
                table: "userCourseProgresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "actionType",
                table: "quests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "quests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "course",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "nftTemplateId",
                table: "course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "issuedAt",
                table: "certificates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "certificates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "certificates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1dd327df-99ba-4d58-a991-07fb4959eb97", null, "User", "USER" },
                    { "b133b37b-4c1c-4545-9c73-6291ff5012c5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_certificates_userId1",
                table: "certificates",
                column: "userId1");

            migrationBuilder.AddForeignKey(
                name: "FK_certificates_AspNetUsers_userId1",
                table: "certificates",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
