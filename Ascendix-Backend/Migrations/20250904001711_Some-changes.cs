using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_userQuizAttempts_moduleQuizzes_moduleQuizId",
                table: "userQuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_userQuest_questId",
                table: "userQuest");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc42881-83aa-473c-8481-2f655a8844e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acb6b0cf-b76d-47f8-a93d-c69994b6c733");

            migrationBuilder.DropColumn(
                name: "quizId",
                table: "quizQuestions");

            migrationBuilder.RenameColumn(
                name: "moduleQuizId",
                table: "userQuizAttempts",
                newName: "moduleQuizid");

            migrationBuilder.RenameIndex(
                name: "IX_userQuizAttempts_moduleQuizId",
                table: "userQuizAttempts",
                newName: "IX_userQuizAttempts_moduleQuizid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "moduleQuizzes",
                newName: "id");

            migrationBuilder.AlterColumn<Guid>(
                name: "moduleQuizId",
                table: "quizQuestions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "005d55bf-5a00-4f5e-8bb2-9259c6b41eee", null, "Admin", "ADMIN" },
                    { "dec12e0f-5991-47f5-a6f4-f4f2495e22dc", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userQuest_questId",
                table: "userQuest",
                column: "questId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions",
                column: "moduleQuizId",
                principalTable: "moduleQuizzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userQuizAttempts_moduleQuizzes_moduleQuizid",
                table: "userQuizAttempts",
                column: "moduleQuizid",
                principalTable: "moduleQuizzes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_userQuizAttempts_moduleQuizzes_moduleQuizid",
                table: "userQuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_userQuest_questId",
                table: "userQuest");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "005d55bf-5a00-4f5e-8bb2-9259c6b41eee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dec12e0f-5991-47f5-a6f4-f4f2495e22dc");

            migrationBuilder.RenameColumn(
                name: "moduleQuizid",
                table: "userQuizAttempts",
                newName: "moduleQuizId");

            migrationBuilder.RenameIndex(
                name: "IX_userQuizAttempts_moduleQuizid",
                table: "userQuizAttempts",
                newName: "IX_userQuizAttempts_moduleQuizId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "moduleQuizzes",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "moduleQuizId",
                table: "quizQuestions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "quizId",
                table: "quizQuestions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5bc42881-83aa-473c-8481-2f655a8844e5", null, "User", "USER" },
                    { "acb6b0cf-b76d-47f8-a93d-c69994b6c733", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userQuest_questId",
                table: "userQuest",
                column: "questId");

            migrationBuilder.AddForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions",
                column: "moduleQuizId",
                principalTable: "moduleQuizzes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userQuizAttempts_moduleQuizzes_moduleQuizId",
                table: "userQuizAttempts",
                column: "moduleQuizId",
                principalTable: "moduleQuizzes",
                principalColumn: "Id");
        }
    }
}
