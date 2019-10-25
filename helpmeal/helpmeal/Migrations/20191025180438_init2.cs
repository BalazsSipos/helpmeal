using Microsoft.EntityFrameworkCore.Migrations;

namespace helpmeal.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Recipes_RecipeId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_AspNetUsers_UserId",
                table: "Meal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5323d39e-78a5-45ad-be6b-792cf2b89000");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_UserId",
                table: "Meals",
                newName: "IX_Meals_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_RecipeId",
                table: "Meals",
                newName: "IX_Meals_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "MealId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "419dc516-ceec-44a4-b952-53cb891492da", "5ff53a89-678a-4ded-9310-3a21de5d7623", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Recipes_RecipeId",
                table: "Meals",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_UserId",
                table: "Meals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Recipes_RecipeId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_UserId",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "419dc516-ceec-44a4-b952-53cb891492da");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_UserId",
                table: "Meal",
                newName: "IX_Meal_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_RecipeId",
                table: "Meal",
                newName: "IX_Meal_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "MealId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5323d39e-78a5-45ad-be6b-792cf2b89000", "b3a4f9e7-ff82-41df-a665-b5b6b27715e8", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Recipes_RecipeId",
                table: "Meal",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_AspNetUsers_UserId",
                table: "Meal",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
