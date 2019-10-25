using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace helpmeal.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "691276d6-adeb-4d3f-bffb-cc2e63b4a9bd");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SpecialDate",
                table: "Meals",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c79cd0b3-ecdc-4be9-bcde-7972447f2f38", "d7ebf6ed-014b-4a7c-873d-45e4c9271ce8", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c79cd0b3-ecdc-4be9-bcde-7972447f2f38");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SpecialDate",
                table: "Meals",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "691276d6-adeb-4d3f-bffb-cc2e63b4a9bd", "342f22e5-188b-4221-a415-3b4e17ca2ce9", "User", "USER" });
        }
    }
}
