using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    walletAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totalPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "library",
                columns: table => new
                {
                    libraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    libraryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_library", x => x.libraryId);
                });

            migrationBuilder.CreateTable(
                name: "quests",
                columns: table => new
                {
                    questId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tokenAllocation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quests", x => x.questId);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "course",
                columns: table => new
                {
                    courseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    libraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tokenAllocation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_course_library_libraryId",
                        column: x => x.libraryId,
                        principalTable: "library",
                        principalColumn: "libraryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userQuest",
                columns: table => new
                {
                    userQuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    questId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    completedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userQuest", x => x.userQuestId);
                    table.ForeignKey(
                        name: "FK_userQuest_AspNetUsers_userId1",
                        column: x => x.userId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_userQuest_quests_questId",
                        column: x => x.questId,
                        principalTable: "quests",
                        principalColumn: "questId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "certificates",
                columns: table => new
                {
                    certificateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    courseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    metaDataUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificates", x => x.certificateId);
                    table.ForeignKey(
                        name: "FK_certificates_course_courseId",
                        column: x => x.courseId,
                        principalTable: "course",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "modules",
                columns: table => new
                {
                    moduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    courseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modules", x => x.moduleId);
                    table.ForeignKey(
                        name: "FK_modules_course_courseId",
                        column: x => x.courseId,
                        principalTable: "course",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userCourseProgresses",
                columns: table => new
                {
                    progressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    courseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    progressPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    completedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCourseProgresses", x => x.progressId);
                    table.ForeignKey(
                        name: "FK_userCourseProgresses_AspNetUsers_userId1",
                        column: x => x.userId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_userCourseProgresses_course_courseId",
                        column: x => x.courseId,
                        principalTable: "course",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "moduleQuizzes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    moduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleQuizzes", x => x.id);
                    table.ForeignKey(
                        name: "FK_moduleQuizzes_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "modules",
                        principalColumn: "moduleId",
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
                    moduleQuizid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizQuestions", x => x.id);
                    table.ForeignKey(
                        name: "FK_quizQuestions_moduleQuizzes_moduleQuizid",
                        column: x => x.moduleQuizid,
                        principalTable: "moduleQuizzes",
                        principalColumn: "id");
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
                    moduleQuizid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_userQuizAttempts_moduleQuizzes_moduleQuizid",
                        column: x => x.moduleQuizid,
                        principalTable: "moduleQuizzes",
                        principalColumn: "id");
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
                    { "4c490730-c7be-4444-99ac-5e5958d26cba", null, "Admin", "ADMIN" },
                    { "eb10326f-6987-4bea-9b8a-4763152cca55", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_certificates_courseId",
                table: "certificates",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_libraryId",
                table: "course",
                column: "libraryId");

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
                name: "IX_modules_courseId",
                table: "modules",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_questionOptions_quizQuestionsid",
                table: "questionOptions",
                column: "quizQuestionsid");

            migrationBuilder.CreateIndex(
                name: "IX_quizQuestions_moduleQuizid",
                table: "quizQuestions",
                column: "moduleQuizid");

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
                name: "IX_userCourseProgresses_courseId",
                table: "userCourseProgresses",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_userCourseProgresses_userId1",
                table: "userCourseProgresses",
                column: "userId1");

            migrationBuilder.CreateIndex(
                name: "IX_userQuest_questId",
                table: "userQuest",
                column: "questId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userQuest_userId1",
                table: "userQuest",
                column: "userId1");

            migrationBuilder.CreateIndex(
                name: "IX_userQuizAttempts_moduleQuizid",
                table: "userQuizAttempts",
                column: "moduleQuizid");

            migrationBuilder.CreateIndex(
                name: "IX_userQuizAttempts_userId",
                table: "userQuizAttempts",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "courseTags");

            migrationBuilder.DropTable(
                name: "leaderBoards");

            migrationBuilder.DropTable(
                name: "userAnswers");

            migrationBuilder.DropTable(
                name: "userCertificates");

            migrationBuilder.DropTable(
                name: "userCourseProgresses");

            migrationBuilder.DropTable(
                name: "userQuest");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "questionOptions");

            migrationBuilder.DropTable(
                name: "userQuizAttempts");

            migrationBuilder.DropTable(
                name: "certificates");

            migrationBuilder.DropTable(
                name: "quests");

            migrationBuilder.DropTable(
                name: "quizQuestions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "moduleQuizzes");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "library");
        }
    }
}
