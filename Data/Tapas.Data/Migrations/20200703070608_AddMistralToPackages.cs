namespace Tapas.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddMistralToPackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxProducts",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "MistralCode",
                table: "Packages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MistralName",
                table: "Packages",
                nullable: false,
                defaultValue: string.Empty);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MistralCode",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "MistralName",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "MaxProducts",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
