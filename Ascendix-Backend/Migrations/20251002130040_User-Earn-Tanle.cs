using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UserEarnTanle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaderBoards");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d1d1640-f6fe-474f-94a2-fc9fc48e863c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7fc6313-a1a0-4ef7-9732-d5bc3dc1a23f");

            migrationBuilder.CreateTable(
                name: "userEarns",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    amountEarned = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    earnedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userEarns", x => x.id);
                    table.ForeignKey(
                        name: "FK_userEarns_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "userPays",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amountPayed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    paymentStatus = table.Column<int>(type: "int", nullable: false),
                    datePayed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userPays", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "430aee11-6c09-45df-817a-64f3edba5f71", null, "User", "USER" },
                    { "d925eac2-e355-497d-8ab9-946b6ea57fdd", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userEarns_userId",
                table: "userEarns",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userEarns");

            migrationBuilder.DropTable(
                name: "userPays");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "430aee11-6c09-45df-817a-64f3edba5f71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d925eac2-e355-497d-8ab9-946b6ea57fdd");

            migrationBuilder.CreateTable(
                name: "leaderBoards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    earnings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rank = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d1d1640-f6fe-474f-94a2-fc9fc48e863c", null, "Admin", "ADMIN" },
                    { "f7fc6313-a1a0-4ef7-9732-d5bc3dc1a23f", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaderBoards_userId",
                table: "leaderBoards",
                column: "userId");
        }
    }
}
