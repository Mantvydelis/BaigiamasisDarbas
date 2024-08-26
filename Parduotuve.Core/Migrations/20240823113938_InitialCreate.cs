using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parduotuve.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pardavejai",
                columns: table => new
                {
                    PardavejoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pavarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElPastas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNumeris = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pardavejai", x => x.PardavejoId);
                });

            migrationBuilder.CreateTable(
                name: "Pirkejai",
                columns: table => new
                {
                    PirkejoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pavarde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElPastas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNumeris = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pirkejai", x => x.PirkejoId);
                });

            migrationBuilder.CreateTable(
                name: "Produktai",
                columns: table => new
                {
                    ProduktoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pavadinimas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kaina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kategorija = table.Column<int>(type: "int", nullable: false),
                    KiekisSandelyje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produktai", x => x.ProduktoId);
                });

            migrationBuilder.CreateTable(
                name: "Uzsakymai",
                columns: table => new
                {
                    UzsakymoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PardavejoId = table.Column<int>(type: "int", nullable: false),
                    PirkejoId = table.Column<int>(type: "int", nullable: false),
                    ProduktoId = table.Column<int>(type: "int", nullable: false),
                    UzsakymoData = table.Column<DateOnly>(type: "date", nullable: false),
                    Kiekis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzsakymai", x => x.UzsakymoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pardavejai");

            migrationBuilder.DropTable(
                name: "Pirkejai");

            migrationBuilder.DropTable(
                name: "Produktai");

            migrationBuilder.DropTable(
                name: "Uzsakymai");
        }
    }
}
