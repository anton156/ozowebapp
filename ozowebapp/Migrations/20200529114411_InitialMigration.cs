using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ozowebapp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oprema",
                columns: table => new
                {
                    OpremaClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: true),
                    Cijena = table.Column<double>(nullable: true),
                    Duljina_Koristenja_u_h = table.Column<double>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true),
                    Datum_proizvodnje = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprema", x => x.OpremaClassID);
                });

            migrationBuilder.CreateTable(
                name: "Zanimanje",
                columns: table => new
                {
                    ZanimanjeClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Satnica = table.Column<double>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanimanje", x => x.ZanimanjeClassID);
                });

            migrationBuilder.CreateTable(
                name: "Djelatnik",
                columns: table => new
                {
                    DjelatnikClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    ZanimanjeClassID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Datum_rodjenja = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djelatnik", x => x.DjelatnikClassID);
                    table.ForeignKey(
                        name: "FK_Djelatnik_Zanimanje_ZanimanjeClassID",
                        column: x => x.ZanimanjeClassID,
                        principalTable: "Zanimanje",
                        principalColumn: "ZanimanjeClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Djelatnik_ZanimanjeClassID",
                table: "Djelatnik",
                column: "ZanimanjeClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Djelatnik");

            migrationBuilder.DropTable(
                name: "Oprema");

            migrationBuilder.DropTable(
                name: "Zanimanje");
        }
    }
}
