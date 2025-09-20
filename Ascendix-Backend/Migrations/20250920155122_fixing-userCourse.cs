using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class fixinguserCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCourseProgresses_AspNetUsers_userId1",
                table: "userCourseProgresses");

            migrationBuilder.DropIndex(
                name: "IX_userCourseProgresses_userId1",
                table: "userCourseProgresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd183a2-1aa9-4170-9955-1a10c587df39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2156e65b-899b-483a-9204-c1d7ffba2697");

            migrationBuilder.DropColumn(
                name: "userId1",
                table: "userCourseProgresses");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "userCourseProgresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "libraryName",
                table: "library",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8451d8fc-9ae5-4fbb-b1f3-d2085a33667f", null, "Admin", "ADMIN" },
                    { "f257481c-33e6-4186-9035-5c881ca477aa", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userCourseProgresses_userId",
                table: "userCourseProgresses",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_userCourseProgresses_AspNetUsers_userId",
                table: "userCourseProgresses",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCourseProgresses_AspNetUsers_userId",
                table: "userCourseProgresses");

            migrationBuilder.DropIndex(
                name: "IX_userCourseProgresses_userId",
                table: "userCourseProgresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8451d8fc-9ae5-4fbb-b1f3-d2085a33667f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f257481c-33e6-4186-9035-5c881ca477aa");

            migrationBuilder.AlterColumn<Guid>(
                name: "userId",
                table: "userCourseProgresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId1",
                table: "userCourseProgresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "libraryName",
                table: "library",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bd183a2-1aa9-4170-9955-1a10c587df39", null, "User", "USER" },
                    { "2156e65b-899b-483a-9204-c1d7ffba2697", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_userCourseProgresses_userId1",
                table: "userCourseProgresses",
                column: "userId1");

            migrationBuilder.AddForeignKey(
                name: "FK_userCourseProgresses_AspNetUsers_userId1",
                table: "userCourseProgresses",
                column: "userId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
