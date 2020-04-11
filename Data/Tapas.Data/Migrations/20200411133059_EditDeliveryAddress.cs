namespace Tapas.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditDeliveryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Еntry",
                table: "DeliveryAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Entry",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUseOn",
                table: "DeliveryAddresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entry",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "LastUseOn",
                table: "DeliveryAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Еntry",
                table: "DeliveryAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
