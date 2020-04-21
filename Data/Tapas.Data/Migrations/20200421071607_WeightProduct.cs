namespace Tapas.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class WeightProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");
        }
    }
}
