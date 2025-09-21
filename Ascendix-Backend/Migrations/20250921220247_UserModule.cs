using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UserModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8451d8fc-9ae5-4fbb-b1f3-d2085a33667f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f257481c-33e6-4186-9035-5c881ca477aa");

            migrationBuilder.AlterColumn<int>(
                name: "score",
                table: "userQuizAttempts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "questionScore",
                table: "quizQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ebbdc74-7375-49fa-9d81-8159af1d35cc", null, "User", "USER" },
                    { "94c1ed7c-8fb1-4ea2-9ab5-841f8354d866", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ebbdc74-7375-49fa-9d81-8159af1d35cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c1ed7c-8fb1-4ea2-9ab5-841f8354d866");

            migrationBuilder.DropColumn(
                name: "questionScore",
                table: "quizQuestions");

            migrationBuilder.AlterColumn<decimal>(
                name: "score",
                table: "userQuizAttempts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8451d8fc-9ae5-4fbb-b1f3-d2085a33667f", null, "Admin", "ADMIN" },
                    { "f257481c-33e6-4186-9035-5c881ca477aa", null, "User", "USER" }
                });
        }
    }
}
