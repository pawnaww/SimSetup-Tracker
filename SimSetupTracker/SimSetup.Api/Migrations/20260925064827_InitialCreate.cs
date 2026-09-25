using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimSetup.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    LengthKm = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false),
                    LapTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    TirePressureFront = table.Column<double>(type: "REAL", nullable: false),
                    TirePressureRear = table.Column<double>(type: "REAL", nullable: false),
                    AeroFront = table.Column<int>(type: "INTEGER", nullable: false),
                    AeroRear = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setups_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Setups_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "Ferrari", "488 GT3 Evo", 2020 },
                    { 2, "Porsche", "911 GT3 R (992)", 2023 },
                    { 3, "BMW", "M4 GT3", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Country", "LengthKm", "Name" },
                values: new object[,]
                {
                    { 1, "Belgium", 7.0039999999999996, "Circuit de Spa-Francorchamps" },
                    { 2, "Italy", 5.7930000000000001, "Autodromo Nazionale Monza" },
                    { 3, "Germany", 5.1479999999999997, "Nürburgring GP" }
                });

            migrationBuilder.InsertData(
                table: "Setups",
                columns: new[] { "Id", "AeroFront", "AeroRear", "CarId", "CreatedAt", "LapTime", "Notes", "TirePressureFront", "TirePressureRear", "TrackId" },
                values: new object[] { 1, 4, 8, 1, new DateTime(2026, 9, 20, 12, 0, 0, 0, DateTimeKind.Utc), new TimeSpan(0, 0, 2, 18, 450), "Bazowy setup na suchy tor Spa. Stabilny tył w Eau Rouge.", 27.5, 27.199999999999999, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Setups_CarId",
                table: "Setups",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Setups_TrackId",
                table: "Setups",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setups");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
