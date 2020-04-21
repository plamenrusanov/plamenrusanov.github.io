using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tapas.Data.Migrations
{
    public partial class AddPackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ShopingCartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    MaxProducts = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PackageId",
                table: "Products",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_IsDeleted",
                table: "Packages",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Packages_PackageId",
                table: "Products",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Packages_PackageId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Products_PackageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ShopingCartItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Products");
        }
    }
}
