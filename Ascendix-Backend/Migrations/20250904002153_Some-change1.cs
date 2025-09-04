using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Somechange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "268a4811-8d2a-4f23-84d4-73ddad466e85", null, "Admin", "ADMIN" },
                    { "481e1723-3a00-4ceb-9eb3-1c87e82f2f8d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "268a4811-8d2a-4f23-84d4-73ddad466e85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "481e1723-3a00-4ceb-9eb3-1c87e82f2f8d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8627de50-c30d-4e38-9f3a-fc0ad18a1d10", null, "User", "USER" },
                    { "cb092689-2fe3-4c1b-8619-030e11592f83", null, "Admin", "ADMIN" }
                });
        }
    }
}
