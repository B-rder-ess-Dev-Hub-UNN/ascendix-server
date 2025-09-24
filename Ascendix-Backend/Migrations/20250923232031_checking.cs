using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class checking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userAnswers_quizQuestions_questionId",
                table: "userAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e3b7f81-d707-44f5-9aa4-1c6ff5d1a3c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76c2e6f-795c-415d-a9f7-381443b41dce");

            migrationBuilder.RenameColumn(
                name: "questionId",
                table: "userAnswers",
                newName: "quizQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_userAnswers_questionId",
                table: "userAnswers",
                newName: "IX_userAnswers_quizQuestionId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d1d1640-f6fe-474f-94a2-fc9fc48e863c", null, "Admin", "ADMIN" },
                    { "f7fc6313-a1a0-4ef7-9732-d5bc3dc1a23f", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_userAnswers_quizQuestions_quizQuestionId",
                table: "userAnswers",
                column: "quizQuestionId",
                principalTable: "quizQuestions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userAnswers_quizQuestions_quizQuestionId",
                table: "userAnswers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1d1640-f6fe-474f-94a2-fc9fc48e863c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7fc6313-a1a0-4ef7-9732-d5bc3dc1a23f");

            migrationBuilder.RenameColumn(
                name: "quizQuestionId",
                table: "userAnswers",
                newName: "questionId");

            migrationBuilder.RenameIndex(
                name: "IX_userAnswers_quizQuestionId",
                table: "userAnswers",
                newName: "IX_userAnswers_questionId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e3b7f81-d707-44f5-9aa4-1c6ff5d1a3c9", null, "Admin", "ADMIN" },
                    { "c76c2e6f-795c-415d-a9f7-381443b41dce", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_userAnswers_quizQuestions_questionId",
                table: "userAnswers",
                column: "questionId",
                principalTable: "quizQuestions",
                principalColumn: "id");
        }
    }
}
