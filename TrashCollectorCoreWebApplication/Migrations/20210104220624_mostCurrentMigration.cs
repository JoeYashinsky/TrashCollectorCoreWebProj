using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorCoreWebApplication.Migrations
{
    public partial class mostCurrentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4779d39-e594-4df6-935e-08359ff74c25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e90146e0-67a4-4fea-987d-54a0864bc343");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57245d6f-9c63-4162-9370-8204c552ee92", "4d67d54b-e401-4f0e-b101-a9860b0d8213", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc7b4742-4b8a-4d70-81aa-ce5a98fe2092", "a5f1443c-47c0-4dc6-bf08-8137e6f8f471", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e90146e0-67a4-4fea-987d-54a0864bc343", "f048f977-c4fd-44c9-b65c-434b415964f5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4779d39-e594-4df6-935e-08359ff74c25", "1dcaec67-24ca-4ca6-9324-cf53c78559b6", "Employee", "EMPLOYEE" });
        }
    }
}
