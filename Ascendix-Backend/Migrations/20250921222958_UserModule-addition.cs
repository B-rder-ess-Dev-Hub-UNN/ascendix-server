using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UserModuleaddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ebbdc74-7375-49fa-9d81-8159af1d35cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c1ed7c-8fb1-4ea2-9ab5-841f8354d866");

            migrationBuilder.CreateTable(
                name: "userModules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    moduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    progressPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userModules", x => x.id);
                    table.ForeignKey(
                        name: "FK_userModules_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_userModules_modules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "modules",
                        principalColumn: "moduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e3b7f81-d707-44f5-9aa4-1c6ff5d1a3c9", null, "Admin", "ADMIN" },
                    { "c76c2e6f-795c-415d-a9f7-381443b41dce", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userModules_moduleId",
                table: "userModules",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_userModules_userId",
                table: "userModules",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userModules");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e3b7f81-d707-44f5-9aa4-1c6ff5d1a3c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76c2e6f-795c-415d-a9f7-381443b41dce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ebbdc74-7375-49fa-9d81-8159af1d35cc", null, "User", "USER" },
                    { "94c1ed7c-8fb1-4ea2-9ab5-841f8354d866", null, "Admin", "ADMIN" }
                });
        }
    }
}
