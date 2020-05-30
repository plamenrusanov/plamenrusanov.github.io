namespace Tapas.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CateringProductSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeId",
                table: "Products",
                column: "SizeId",
                unique: true,
                filter: "[SizeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSizes_SizeId",
                table: "Products",
                column: "SizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSizes_SizeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SizeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Products");
        }
    }
}
