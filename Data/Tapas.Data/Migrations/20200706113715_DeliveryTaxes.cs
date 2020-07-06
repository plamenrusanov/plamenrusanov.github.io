namespace Tapas.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DeliveryTaxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryTaxId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryTaxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    MistralCode = table.Column<int>(nullable: false),
                    MistralName = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTaxes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryTaxId",
                table: "Orders",
                column: "DeliveryTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTaxes_IsDeleted",
                table: "DeliveryTaxes",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryTaxes_DeliveryTaxId",
                table: "Orders",
                column: "DeliveryTaxId",
                principalTable: "DeliveryTaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryTaxes_DeliveryTaxId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryTaxes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryTaxId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryTaxId",
                table: "Orders");
        }
    }
}
