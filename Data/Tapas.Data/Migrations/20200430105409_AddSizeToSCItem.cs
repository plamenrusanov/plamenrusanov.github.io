using Microsoft.EntityFrameworkCore.Migrations;

namespace Tapas.Data.Migrations
{
    public partial class AddSizeToSCItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ShopingCartItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCartItems_SizeId",
                table: "ShopingCartItems",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCartItems_ProductSizes_SizeId",
                table: "ShopingCartItems",
                column: "SizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCartItems_ProductSizes_SizeId",
                table: "ShopingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopingCartItems_SizeId",
                table: "ShopingCartItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ShopingCartItems");
        }
    }
}
