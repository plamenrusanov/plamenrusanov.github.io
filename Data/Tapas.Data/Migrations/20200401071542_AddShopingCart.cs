namespace Tapas.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddShopingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopingCartId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryAddresses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    AddInfo = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: false),
                    CustomerId1 = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAddresses_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryAddresses_AspNetUsers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopingCarts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<string>(nullable: false),
                    AddInfo = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopingCarts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    AddInfo = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: false),
                    AddressId = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "DeliveryAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: false),
                    OrderId1 = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ShopingCartId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopingCartItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopingCartItems_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopingCartItems_ShopingCarts_ShopingCartId",
                        column: x => x.ShopingCartId,
                        principalTable: "ShopingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShopingCartId",
                table: "AspNetUsers",
                column: "ShopingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_CustomerId",
                table: "DeliveryAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_CustomerId1",
                table: "DeliveryAddresses",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddresses_IsDeleted",
                table: "DeliveryAddresses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCartItems_OrderId",
                table: "ShopingCartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCartItems_OrderId1",
                table: "ShopingCartItems",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCartItems_ProductId",
                table: "ShopingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCartItems_ShopingCartId",
                table: "ShopingCartItems",
                column: "ShopingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCarts_CustomerId",
                table: "ShopingCarts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCarts_IsDeleted",
                table: "ShopingCarts",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShopingCarts_ShopingCartId",
                table: "AspNetUsers",
                column: "ShopingCartId",
                principalTable: "ShopingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShopingCarts_ShopingCartId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ShopingCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShopingCarts");

            migrationBuilder.DropTable(
                name: "DeliveryAddresses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShopingCartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShopingCartId",
                table: "AspNetUsers");
        }
    }
}
