using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace helpmeal.Migrations
{
    public partial class mealsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d2cd90a-05cc-4ca8-8972-bfd1cbe74f50");

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    MealId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    CycleDay = table.Column<byte>(nullable: false),
                    RecipeId = table.Column<long>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    SpecialDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meal_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meal_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5323d39e-78a5-45ad-be6b-792cf2b89000", "b3a4f9e7-ff82-41df-a665-b5b6b27715e8", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Meal_RecipeId",
                table: "Meal",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_UserId",
                table: "Meal",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5323d39e-78a5-45ad-be6b-792cf2b89000");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Recipes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d2cd90a-05cc-4ca8-8972-bfd1cbe74f50", "33ad3bc8-7a75-44fa-b0df-3355b824aa90", "User", "USER" });
        }
    }
}
