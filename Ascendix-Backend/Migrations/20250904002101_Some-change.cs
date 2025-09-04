using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Somechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "005d55bf-5a00-4f5e-8bb2-9259c6b41eee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dec12e0f-5991-47f5-a6f4-f4f2495e22dc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8627de50-c30d-4e38-9f3a-fc0ad18a1d10", null, "User", "USER" },
                    { "cb092689-2fe3-4c1b-8619-030e11592f83", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8627de50-c30d-4e38-9f3a-fc0ad18a1d10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb092689-2fe3-4c1b-8619-030e11592f83");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "005d55bf-5a00-4f5e-8bb2-9259c6b41eee", null, "Admin", "ADMIN" },
                    { "dec12e0f-5991-47f5-a6f4-f4f2495e22dc", null, "User", "USER" }
                });
        }
    }
}
