namespace Tapas.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddExtraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_ShopingCartItems_ShopingCartItemId",
                table: "Extras");

            migrationBuilder.DropIndex(
                name: "IX_Extras_ShopingCartItemId",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "ShopingCartItemId",
                table: "Extras");

            migrationBuilder.CreateTable(
                name: "ExtraItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ExtraId = table.Column<int>(nullable: false),
                    ShopingCartItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraItems_Extras_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraItems_ShopingCartItems_ShopingCartItemId",
                        column: x => x.ShopingCartItemId,
                        principalTable: "ShopingCartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraItems_ExtraId",
                table: "ExtraItems",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraItems_IsDeleted",
                table: "ExtraItems",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraItems_ShopingCartItemId",
                table: "ExtraItems",
                column: "ShopingCartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraItems");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Extras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopingCartItemId",
                table: "Extras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Extras_ShopingCartItemId",
                table: "Extras",
                column: "ShopingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_ShopingCartItems_ShopingCartItemId",
                table: "Extras",
                column: "ShopingCartItemId",
                principalTable: "ShopingCartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
