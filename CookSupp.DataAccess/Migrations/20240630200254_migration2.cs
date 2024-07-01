using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookSupp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Recipes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RecipeStepId",
                table: "RecipeProduct",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Fridges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ApplicationUserId",
                table: "Recipes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProduct_RecipeStepId",
                table: "RecipeProduct",
                column: "RecipeStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeProduct_RecipeSteps_RecipeStepId",
                table: "RecipeProduct",
                column: "RecipeStepId",
                principalTable: "RecipeSteps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AspNetUsers_ApplicationUserId",
                table: "Recipes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeProduct_RecipeSteps_RecipeStepId",
                table: "RecipeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AspNetUsers_ApplicationUserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ApplicationUserId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_RecipeProduct_RecipeStepId",
                table: "RecipeProduct");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeStepId",
                table: "RecipeProduct");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Fridges");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
