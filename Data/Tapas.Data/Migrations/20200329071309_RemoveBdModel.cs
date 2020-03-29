namespace Tapas.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveBdModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AllergensProducts_IsDeleted",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AllergensProducts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AllergensProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AllergensProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AllergensProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AllergensProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AllergensProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AllergensProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllergensProducts_IsDeleted",
                table: "AllergensProducts",
                column: "IsDeleted");
        }
    }
}
