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
                name: "plantspecies",
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
                    table.PrimaryKey("PK_plantspecies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zone",
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
                    table.PrimaryKey("PK_zone", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "facility",
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
                    table.PrimaryKey("PK_facility", x => x.id);
                    table.ForeignKey(
                        name: "FK_facility_zone_zoneid",
                        column: x => x.zoneid,
                        principalTable: "zone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "zoneplant",
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
                    table.PrimaryKey("PK_zoneplant", x => x.id);
                    table.CheckConstraint("CK_ZonePlant_Density", "[density] IN ('rare', 'medium', 'common')");
                    table.ForeignKey(
                        name: "FK_zoneplant_plantspecies_plantid",
                        column: x => x.plantid,
                        principalTable: "plantspecies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_zoneplant_zone_zoneid",
                        column: x => x.zoneid,
                        principalTable: "zone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_facility_zoneid",
                table: "facility",
                column: "zoneid");

            migrationBuilder.CreateIndex(
                name: "IX_plantspecies_latinname",
                table: "plantspecies",
                column: "latinname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plantspecies_name",
                table: "plantspecies",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_zoneplant_plantid",
                table: "zoneplant",
                column: "plantid");

            migrationBuilder.CreateIndex(
                name: "IX_zoneplant_zoneid_plantid",
                table: "zoneplant",
                columns: new[] { "zoneid", "plantid" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "facility");

            migrationBuilder.DropTable(
                name: "zoneplant");

            migrationBuilder.DropTable(
                name: "plantspecies");

            migrationBuilder.DropTable(
                name: "zone");
        }
    }
}
