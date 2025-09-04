using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class fixederror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "268a4811-8d2a-4f23-84d4-73ddad466e85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "481e1723-3a00-4ceb-9eb3-1c87e82f2f8d");

            migrationBuilder.AlterColumn<Guid>(
                name: "moduleQuizId",
                table: "quizQuestions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f846dec-e2af-4889-9009-06fadbdc043d", null, "User", "USER" },
                    { "e13a3863-d538-4c43-85f0-43fc1d5c2674", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions",
                column: "moduleQuizId",
                principalTable: "moduleQuizzes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f846dec-e2af-4889-9009-06fadbdc043d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e13a3863-d538-4c43-85f0-43fc1d5c2674");

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
                    { "268a4811-8d2a-4f23-84d4-73ddad466e85", null, "Admin", "ADMIN" },
                    { "481e1723-3a00-4ceb-9eb3-1c87e82f2f8d", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_quizQuestions_moduleQuizzes_moduleQuizId",
                table: "quizQuestions",
                column: "moduleQuizId",
                principalTable: "moduleQuizzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
