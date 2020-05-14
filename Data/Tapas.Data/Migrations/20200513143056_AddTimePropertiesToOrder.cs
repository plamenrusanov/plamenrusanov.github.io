using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tapas.Data.Migrations
{
    public partial class AddTimePropertiesToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MinutesForDelivery",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OnDeliveryTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessingTime",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveredTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MinutesForDelivery",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OnDeliveryTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProcessingTime",
                table: "Orders");
        }
    }
}
