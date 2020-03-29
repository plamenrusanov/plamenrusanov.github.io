namespace Tapas.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateEntitiesToBaseDeletableModel : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Allergens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Allergens",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Allergens",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Allergens",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllergensProducts_IsDeleted",
                table: "AllergensProducts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Allergens_IsDeleted",
                table: "Allergens",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AllergensProducts_IsDeleted",
                table: "AllergensProducts");

            migrationBuilder.DropIndex(
                name: "IX_Allergens_IsDeleted",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Allergens");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Allergens");
        }
    }
}
