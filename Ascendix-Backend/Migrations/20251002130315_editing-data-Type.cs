using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ascendix_Backend.Migrations
{
    /// <inheritdoc />
    public partial class editingdataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "430aee11-6c09-45df-817a-64f3edba5f71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d925eac2-e355-497d-8ab9-946b6ea57fdd");

            migrationBuilder.AlterColumn<int>(
                name: "progressPercent",
                table: "userModules",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "progressPercent",
                table: "userCourseProgresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1480bac-27dc-4e04-b562-4f6dccbe9419", null, "Admin", "ADMIN" },
                    { "dbe865c5-7645-45e6-8f97-91ff5dccbec7", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1480bac-27dc-4e04-b562-4f6dccbe9419");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe865c5-7645-45e6-8f97-91ff5dccbec7");

            migrationBuilder.AlterColumn<decimal>(
                name: "progressPercent",
                table: "userModules",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "progressPercent",
                table: "userCourseProgresses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "430aee11-6c09-45df-817a-64f3edba5f71", null, "User", "USER" },
                    { "d925eac2-e355-497d-8ab9-946b6ea57fdd", null, "Admin", "ADMIN" }
                });
        }
    }
}
