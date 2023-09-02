using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeInventoryManagement.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SqFtSize = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bike",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrameSizeCm = table.Column<int>(type: "int", nullable: false),
                    BikeTypeID = table.Column<int>(type: "int", nullable: true),
                    IsBoxed = table.Column<bool>(type: "bit", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageLocationID = table.Column<int>(type: "int", nullable: true),
                    IsListable = table.Column<bool>(type: "bit", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: true),
                    InventoryCount = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bike_BikeType_BikeTypeID",
                        column: x => x.BikeTypeID,
                        principalTable: "BikeType",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bike_Location_StorageLocationID",
                        column: x => x.StorageLocationID,
                        principalTable: "Location",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bike_BikeTypeID",
                table: "Bike",
                column: "BikeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_StorageLocationID",
                table: "Bike",
                column: "StorageLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bike");

            migrationBuilder.DropTable(
                name: "BikeType");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
