namespace Tapas.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateDeliveryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StreetNumber",
                table: "DeliveryAddresses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Block",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Borough",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "DeliveryAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Еntry",
                table: "DeliveryAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Block",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "Borough",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "City",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "DeliveryAddresses");

            migrationBuilder.DropColumn(
                name: "Еntry",
                table: "DeliveryAddresses");

            migrationBuilder.AlterColumn<int>(
                name: "StreetNumber",
                table: "DeliveryAddresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
