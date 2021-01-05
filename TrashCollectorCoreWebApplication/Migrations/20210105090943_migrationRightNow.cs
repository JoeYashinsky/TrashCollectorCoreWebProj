using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorCoreWebApplication.Migrations
{
    public partial class migrationRightNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84544177-a57e-4a42-97d5-fdf2f69ae292");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5e96af2-7320-42fd-9f82-bf7a0f548c1b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a221189-05b3-4937-9d0a-87da5fe6debb", "75d2666d-2dd0-4199-b581-1bfd381442e6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "313adf96-cad1-47b9-8177-d5536ff83119", "c3771de4-7064-44af-ae5b-c2e96614ae2f", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "84544177-a57e-4a42-97d5-fdf2f69ae292", "1f54c3d8-1565-4671-a83f-c82e8e3e3266", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5e96af2-7320-42fd-9f82-bf7a0f548c1b", "1513d615-a820-48dd-aa83-58751b93e69b", "Employee", "EMPLOYEE" });
        }
    }
}
