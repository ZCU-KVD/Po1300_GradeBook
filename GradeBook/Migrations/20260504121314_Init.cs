using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeBook.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatumNarozeni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Jmeno = table.Column<string>(type: "TEXT", nullable: false),
                    Prijmeni = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ucitele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titul = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Jmeno = table.Column<string>(type: "TEXT", nullable: false),
                    Prijmeni = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucitele", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predmety",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazev = table.Column<string>(type: "TEXT", nullable: false),
                    Zkratka = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    GarandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predmety_Ucitele_GarandId",
                        column: x => x.GarandId,
                        principalTable: "Ucitele",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Znamky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hodnota = table.Column<int>(type: "INTEGER", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PredmetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Znamky", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Znamky_Predmety_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmety",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Znamky_Studenti_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Predmety_GarandId",
                table: "Predmety",
                column: "GarandId");

            migrationBuilder.CreateIndex(
                name: "IX_Znamky_PredmetId",
                table: "Znamky",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_Znamky_StudentId",
                table: "Znamky",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Znamky");

            migrationBuilder.DropTable(
                name: "Predmety");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Ucitele");
        }
    }
}
