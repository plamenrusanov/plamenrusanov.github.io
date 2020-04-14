using Microsoft.EntityFrameworkCore.Migrations;

namespace Tapas.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShopingCarts_ShopingCartId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShopingCartId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShopingCartId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "BagId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BagId",
                table: "Orders",
                column: "BagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShopingCarts_BagId",
                table: "Orders",
                column: "BagId",
                principalTable: "ShopingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShopingCarts_BagId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BagId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BagId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShopingCartId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopingCartId",
                table: "Orders",
                column: "ShopingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShopingCarts_ShopingCartId",
                table: "Orders",
                column: "ShopingCartId",
                principalTable: "ShopingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
