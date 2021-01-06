using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorCoreWebApplication.Migrations
{
    public partial class trashCollectorsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "313adf96-cad1-47b9-8177-d5536ff83119");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a221189-05b3-4937-9d0a-87da5fe6debb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08779ac6-663b-4ae3-90bc-0953928beb50", "1bae730c-9cd2-4145-8cee-05a671e76a48", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "112bf65b-cf39-4340-8c6b-3fd253d47b73", "d360aa60-9397-4ecd-8299-0843ff0b5741", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08779ac6-663b-4ae3-90bc-0953928beb50");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "112bf65b-cf39-4340-8c6b-3fd253d47b73");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a221189-05b3-4937-9d0a-87da5fe6debb", "75d2666d-2dd0-4199-b581-1bfd381442e6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "313adf96-cad1-47b9-8177-d5536ff83119", "c3771de4-7064-44af-ae5b-c2e96614ae2f", "Employee", "EMPLOYEE" });
        }
    }
}
