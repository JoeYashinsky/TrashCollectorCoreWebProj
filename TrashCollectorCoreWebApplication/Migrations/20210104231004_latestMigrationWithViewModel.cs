using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorCoreWebApplication.Migrations
{
    public partial class latestMigrationWithViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57245d6f-9c63-4162-9370-8204c552ee92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc7b4742-4b8a-4d70-81aa-ce5a98fe2092");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84544177-a57e-4a42-97d5-fdf2f69ae292", "1f54c3d8-1565-4671-a83f-c82e8e3e3266", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5e96af2-7320-42fd-9f82-bf7a0f548c1b", "1513d615-a820-48dd-aa83-58751b93e69b", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "57245d6f-9c63-4162-9370-8204c552ee92", "4d67d54b-e401-4f0e-b101-a9860b0d8213", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc7b4742-4b8a-4d70-81aa-ce5a98fe2092", "a5f1443c-47c0-4dc6-bf08-8137e6f8f471", "Employee", "EMPLOYEE" });
        }
    }
}
