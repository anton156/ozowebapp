using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ozowebapp.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oprema",
                columns: table => new
                {
                    OpremaClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    Duljina_Koristenja_u_h = table.Column<double>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true),
                    Datum_proizvodnje = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprema", x => x.OpremaClassID);
                });

            migrationBuilder.CreateTable(
                name: "UslugaClass",
                columns: table => new
                {
                    UslugaClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugaClass", x => x.UslugaClassID);
                });

            migrationBuilder.CreateTable(
                name: "UslugaViewModel",
                columns: table => new
                {
                    UslugaClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugaViewModel", x => x.UslugaClassID);
                });

            migrationBuilder.CreateTable(
                name: "Zanimanje",
                columns: table => new
                {
                    ZanimanjeClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Satnica = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanimanje", x => x.ZanimanjeClassID);
                });

            migrationBuilder.CreateTable(
                name: "UslugaToOpremas",
                columns: table => new
                {
                    UslugaToOpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaClassID = table.Column<int>(nullable: false),
                    OpremaClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugaToOpremas", x => x.UslugaToOpremaID);
                    table.ForeignKey(
                        name: "FK_UslugaToOpremas_Oprema_OpremaClassID",
                        column: x => x.OpremaClassID,
                        principalTable: "Oprema",
                        principalColumn: "OpremaClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UslugaToOpremas_UslugaClass_UslugaClassID",
                        column: x => x.UslugaClassID,
                        principalTable: "UslugaClass",
                        principalColumn: "UslugaClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckBoxViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    UslugaViewModelUslugaClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBoxViewModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckBoxViewModel_UslugaViewModel_UslugaViewModelUslugaClassID",
                        column: x => x.UslugaViewModelUslugaClassID,
                        principalTable: "UslugaViewModel",
                        principalColumn: "UslugaClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckBoxViewModelOprema",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    UslugaViewModelUslugaClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBoxViewModelOprema", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckBoxViewModelOprema_UslugaViewModel_UslugaViewModelUslugaClassID",
                        column: x => x.UslugaViewModelUslugaClassID,
                        principalTable: "UslugaViewModel",
                        principalColumn: "UslugaClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Djelatnik",
                columns: table => new
                {
                    DjelatnikClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UslugaToZanimanjes",
                columns: table => new
                {
                    UslugaToZanimanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaClassID = table.Column<int>(nullable: false),
                    ZanimanjeClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugaToZanimanjes", x => x.UslugaToZanimanjeID);
                    table.ForeignKey(
                        name: "FK_UslugaToZanimanjes_UslugaClass_UslugaClassID",
                        column: x => x.UslugaClassID,
                        principalTable: "UslugaClass",
                        principalColumn: "UslugaClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UslugaToZanimanjes_Zanimanje_ZanimanjeClassID",
                        column: x => x.ZanimanjeClassID,
                        principalTable: "Zanimanje",
                        principalColumn: "ZanimanjeClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxViewModel_UslugaViewModelUslugaClassID",
                table: "CheckBoxViewModel",
                column: "UslugaViewModelUslugaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxViewModelOprema_UslugaViewModelUslugaClassID",
                table: "CheckBoxViewModelOprema",
                column: "UslugaViewModelUslugaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Djelatnik_ZanimanjeClassID",
                table: "Djelatnik",
                column: "ZanimanjeClassID");

            migrationBuilder.CreateIndex(
                name: "IX_UslugaToOpremas_OpremaClassID",
                table: "UslugaToOpremas",
                column: "OpremaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_UslugaToOpremas_UslugaClassID",
                table: "UslugaToOpremas",
                column: "UslugaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_UslugaToZanimanjes_UslugaClassID",
                table: "UslugaToZanimanjes",
                column: "UslugaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_UslugaToZanimanjes_ZanimanjeClassID",
                table: "UslugaToZanimanjes",
                column: "ZanimanjeClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckBoxViewModel");

            migrationBuilder.DropTable(
                name: "CheckBoxViewModelOprema");

            migrationBuilder.DropTable(
                name: "Djelatnik");

            migrationBuilder.DropTable(
                name: "UslugaToOpremas");

            migrationBuilder.DropTable(
                name: "UslugaToZanimanjes");

            migrationBuilder.DropTable(
                name: "UslugaViewModel");

            migrationBuilder.DropTable(
                name: "Oprema");

            migrationBuilder.DropTable(
                name: "UslugaClass");

            migrationBuilder.DropTable(
                name: "Zanimanje");
        }
    }
}
