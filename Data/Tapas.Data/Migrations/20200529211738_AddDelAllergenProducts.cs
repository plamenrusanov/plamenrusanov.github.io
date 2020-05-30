namespace Tapas.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddDelAllergenProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AllergensProducts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AllergensProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_AllergensProducts_IsDeleted",
                table: "AllergensProducts",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AllergensProducts_IsDeleted",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AllergensProducts");
        }
    }
}
