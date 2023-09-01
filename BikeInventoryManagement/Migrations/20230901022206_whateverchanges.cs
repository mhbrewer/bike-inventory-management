using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeInventoryManagement.Migrations
{
    public partial class whateverchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StorageLocationID",
                table: "Bike",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BikeTypeID",
                table: "Bike",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_BikeTypeID",
                table: "Bike",
                column: "BikeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_StorageLocationID",
                table: "Bike",
                column: "StorageLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_BikeType_BikeTypeID",
                table: "Bike",
                column: "BikeTypeID",
                principalTable: "BikeType",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_Location_StorageLocationID",
                table: "Bike",
                column: "StorageLocationID",
                principalTable: "Location",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bike_BikeType_BikeTypeID",
                table: "Bike");

            migrationBuilder.DropForeignKey(
                name: "FK_Bike_Location_StorageLocationID",
                table: "Bike");

            migrationBuilder.DropIndex(
                name: "IX_Bike_BikeTypeID",
                table: "Bike");

            migrationBuilder.DropIndex(
                name: "IX_Bike_StorageLocationID",
                table: "Bike");

            migrationBuilder.AlterColumn<int>(
                name: "StorageLocationID",
                table: "Bike",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BikeTypeID",
                table: "Bike",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
