using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalPark.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plantsspecies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    latinname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isprotected = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plantsspecies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    areaha = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facilities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zoneid = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "good"),
                    installedon = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilities", x => x.id);
                    table.ForeignKey(
                        name: "FK_facilities_zones_zoneid",
                        column: x => x.zoneid,
                        principalTable: "zones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zonesplants",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zoneid = table.Column<int>(type: "int", nullable: false),
                    plantid = table.Column<int>(type: "int", nullable: false),
                    density = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zonesplants", x => x.id);
                    table.CheckConstraint("CK_ZonePlant_Density", "[density] IN ('rare', 'medium', 'common')");
                    table.ForeignKey(
                        name: "FK_zonesplants_plantsspecies_plantid",
                        column: x => x.plantid,
                        principalTable: "plantsspecies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zonesplants_zones_zoneid",
                        column: x => x.zoneid,
                        principalTable: "zones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_facilities_zoneid",
                table: "facilities",
                column: "zoneid");

            migrationBuilder.CreateIndex(
                name: "IX_plantsspecies_latinname",
                table: "plantsspecies",
                column: "latinname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plantsspecies_name",
                table: "plantsspecies",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_zonesplants_plantid",
                table: "zonesplants",
                column: "plantid");

            migrationBuilder.CreateIndex(
                name: "IX_zonesplants_zoneid_plantid",
                table: "zonesplants",
                columns: new[] { "zoneid", "plantid" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facilities");

            migrationBuilder.DropTable(
                name: "zonesplants");

            migrationBuilder.DropTable(
                name: "plantsspecies");

            migrationBuilder.DropTable(
                name: "zones");
        }
    }
}
