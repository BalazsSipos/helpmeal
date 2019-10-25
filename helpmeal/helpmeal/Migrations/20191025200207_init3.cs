using Microsoft.EntityFrameworkCore.Migrations;

namespace helpmeal.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c79cd0b3-ecdc-4be9-bcde-7972447f2f38");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "224443b0-3a9c-4d06-823c-e7126ca89f6b", "2d277615-3305-4fe5-aa2a-d93a6b975ed1", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "224443b0-3a9c-4d06-823c-e7126ca89f6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c79cd0b3-ecdc-4be9-bcde-7972447f2f38", "d7ebf6ed-014b-4a7c-873d-45e4c9271ce8", "User", "USER" });
        }
    }
}
