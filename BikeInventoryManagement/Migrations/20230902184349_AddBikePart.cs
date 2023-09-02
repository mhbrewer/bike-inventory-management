using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeInventoryManagement.Migrations
{
    public partial class AddBikePart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikePart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBoxed = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_BikePart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BikePart_Location_StorageLocationID",
                        column: x => x.StorageLocationID,
                        principalTable: "Location",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikePart_StorageLocationID",
                table: "BikePart",
                column: "StorageLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikePart");
        }
    }
}
