using Microsoft.EntityFrameworkCore.Migrations;

namespace helpmeal.Migrations
{
    public partial class mod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd16512a-5583-4c89-a907-a8157a5ad0a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e941ee5b-fa69-4123-a1ec-2fe0556188e1", "3315be0d-5d93-41a3-98e0-7d5534720e75", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e941ee5b-fa69-4123-a1ec-2fe0556188e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd16512a-5583-4c89-a907-a8157a5ad0a5", "52dcf938-7715-495c-a88e-89b2cd6b811b", "User", "USER" });
        }
    }
}
