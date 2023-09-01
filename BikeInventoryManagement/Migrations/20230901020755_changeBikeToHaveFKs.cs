using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeInventoryManagement.Migrations
{
    public partial class changeBikeToHaveFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_Location_StorageLocationID",
                table: "Bike",
                column: "StorageLocationID",
                principalTable: "Location",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
