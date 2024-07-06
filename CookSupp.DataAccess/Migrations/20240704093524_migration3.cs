using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookSupp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProduct_Fridges_FridgeId",
                table: "FridgeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProduct_Products_ProductId",
                table: "FridgeProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeProduct",
                table: "FridgeProduct");

            migrationBuilder.RenameTable(
                name: "FridgeProduct",
                newName: "FridgeProducts");

            migrationBuilder.RenameIndex(
                name: "IX_FridgeProduct_ProductId",
                table: "FridgeProducts",
                newName: "IX_FridgeProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeProducts",
                table: "FridgeProducts",
                columns: new[] { "FridgeId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProducts_Fridges_FridgeId",
                table: "FridgeProducts",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProducts_Products_ProductId",
                table: "FridgeProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProducts_Fridges_FridgeId",
                table: "FridgeProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeProducts_Products_ProductId",
                table: "FridgeProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FridgeProducts",
                table: "FridgeProducts");

            migrationBuilder.RenameTable(
                name: "FridgeProducts",
                newName: "FridgeProduct");

            migrationBuilder.RenameIndex(
                name: "IX_FridgeProducts_ProductId",
                table: "FridgeProduct",
                newName: "IX_FridgeProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FridgeProduct",
                table: "FridgeProduct",
                columns: new[] { "FridgeId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProduct_Fridges_FridgeId",
                table: "FridgeProduct",
                column: "FridgeId",
                principalTable: "Fridges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeProduct_Products_ProductId",
                table: "FridgeProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
