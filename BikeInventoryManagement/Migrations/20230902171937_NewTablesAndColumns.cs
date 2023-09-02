using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeInventoryManagement.Migrations
{
    public partial class NewTablesAndColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Location",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BikeType",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "BikeType",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Bike",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Bike",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<bool>(
                name: "InventoryCount",
                table: "Bike",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsListable",
                table: "Bike",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Bike",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<double>(
                name: "ListPrice",
                table: "Bike",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BikeType");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "BikeType");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "InventoryCount",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "IsListable",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Bike");
        }
    }
}
