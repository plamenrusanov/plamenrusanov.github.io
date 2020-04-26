using Microsoft.EntityFrameworkCore.Migrations;

namespace Tapas.Data.Migrations
{
    public partial class AddPropToSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CareringProductId",
                table: "ProductSizes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxProductsInPackage",
                table: "ProductSizes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareringProductId",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "MaxProductsInPackage",
                table: "ProductSizes");
        }
    }
}
