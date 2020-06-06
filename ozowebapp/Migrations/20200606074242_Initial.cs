using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ozowebapp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArhivaNatjecaj",
                columns: table => new
                {
                    ArhivaNatjecajClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true),
                    Pobjednik = table.Column<string>(nullable: true),
                    Zakljucak = table.Column<string>(nullable: true),
                    NatjecajClassID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArhivaNatjecaj", x => x.ArhivaNatjecajClassID);
                });

            migrationBuilder.CreateTable(
                name: "Natjecaj",
                columns: table => new
                {
                    NatjecajClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Lokacija = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natjecaj", x => x.NatjecajClassID);
                });

            migrationBuilder.CreateTable(
                name: "NatjecajViewModels",
                columns: table => new
                {
                    NatjecajClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatjecajViewModels", x => x.NatjecajClassID);
                });

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
                name: "Posao",
                columns: table => new
                {
                    PosaoClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true),
                    Datum_pocetak = table.Column<DateTime>(nullable: false),
                    Datum_kraj = table.Column<DateTime>(nullable: true),
                    UslugaClassID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posao", x => x.PosaoClassID);
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
                    Naziv = table.Column<string>(nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Lokacija = table.Column<string>(nullable: false)
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
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanimanje", x => x.ZanimanjeClassID);
                });

            migrationBuilder.CreateTable(
                name: "NatjecajToOpremas",
                columns: table => new
                {
                    NatjecajToOpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatjecajClassID = table.Column<int>(nullable: false),
                    OpremaClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatjecajToOpremas", x => x.NatjecajToOpremaID);
                    table.ForeignKey(
                        name: "FK_NatjecajToOpremas_Natjecaj_NatjecajClassID",
                        column: x => x.NatjecajClassID,
                        principalTable: "Natjecaj",
                        principalColumn: "NatjecajClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NatjecajToOpremas_Oprema_OpremaClassID",
                        column: x => x.OpremaClassID,
                        principalTable: "Oprema",
                        principalColumn: "OpremaClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PosaoToOpremas",
                columns: table => new
                {
                    PosaoToOpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosaoClassID = table.Column<int>(nullable: false),
                    OpremaClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosaoToOpremas", x => x.PosaoToOpremaID);
                    table.ForeignKey(
                        name: "FK_PosaoToOpremas_Oprema_OpremaClassID",
                        column: x => x.OpremaClassID,
                        principalTable: "Oprema",
                        principalColumn: "OpremaClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PosaoToOpremas_Posao_PosaoClassID",
                        column: x => x.PosaoClassID,
                        principalTable: "Posao",
                        principalColumn: "PosaoClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UslugaToOpremas",
                columns: table => new
                {
                    UslugaToOpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaClassID = table.Column<int>(nullable: false),
                    OpremaClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
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
                    MaxKolicina = table.Column<int>(nullable: false),
                    NatjecajViewModelNatjecajClassID = table.Column<int>(nullable: true),
                    UslugaViewModelUslugaClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBoxViewModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckBoxViewModel_NatjecajViewModels_NatjecajViewModelNatjecajClassID",
                        column: x => x.NatjecajViewModelNatjecajClassID,
                        principalTable: "NatjecajViewModels",
                        principalColumn: "NatjecajClassID",
                        onDelete: ReferentialAction.Restrict);
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
                    MaxKolicina = table.Column<int>(nullable: false),
                    NatjecajViewModelNatjecajClassID = table.Column<int>(nullable: true),
                    UslugaViewModelUslugaClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBoxViewModelOprema", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckBoxViewModelOprema_NatjecajViewModels_NatjecajViewModelNatjecajClassID",
                        column: x => x.NatjecajViewModelNatjecajClassID,
                        principalTable: "NatjecajViewModels",
                        principalColumn: "NatjecajClassID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "NatjecajToZanimanjes",
                columns: table => new
                {
                    NatjecajToZanimanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NatjecajClassID = table.Column<int>(nullable: false),
                    ZanimanjeClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatjecajToZanimanjes", x => x.NatjecajToZanimanjeID);
                    table.ForeignKey(
                        name: "FK_NatjecajToZanimanjes_Natjecaj_NatjecajClassID",
                        column: x => x.NatjecajClassID,
                        principalTable: "Natjecaj",
                        principalColumn: "NatjecajClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NatjecajToZanimanjes_Zanimanje_ZanimanjeClassID",
                        column: x => x.ZanimanjeClassID,
                        principalTable: "Zanimanje",
                        principalColumn: "ZanimanjeClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PosaoToZanimanjes",
                columns: table => new
                {
                    PosaoTozanimanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosaoClassID = table.Column<int>(nullable: false),
                    ZanimanjeClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosaoToZanimanjes", x => x.PosaoTozanimanjeID);
                    table.ForeignKey(
                        name: "FK_PosaoToZanimanjes_Posao_PosaoClassID",
                        column: x => x.PosaoClassID,
                        principalTable: "Posao",
                        principalColumn: "PosaoClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PosaoToZanimanjes_Zanimanje_ZanimanjeClassID",
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
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
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
                name: "IX_CheckBoxViewModel_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModel",
                column: "NatjecajViewModelNatjecajClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxViewModel_UslugaViewModelUslugaClassID",
                table: "CheckBoxViewModel",
                column: "UslugaViewModelUslugaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxViewModelOprema_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModelOprema",
                column: "NatjecajViewModelNatjecajClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxViewModelOprema_UslugaViewModelUslugaClassID",
                table: "CheckBoxViewModelOprema",
                column: "UslugaViewModelUslugaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Djelatnik_ZanimanjeClassID",
                table: "Djelatnik",
                column: "ZanimanjeClassID");

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajToOpremas_NatjecajClassID",
                table: "NatjecajToOpremas",
                column: "NatjecajClassID");

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajToOpremas_OpremaClassID",
                table: "NatjecajToOpremas",
                column: "OpremaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajToZanimanjes_NatjecajClassID",
                table: "NatjecajToZanimanjes",
                column: "NatjecajClassID");

            migrationBuilder.CreateIndex(
                name: "IX_NatjecajToZanimanjes_ZanimanjeClassID",
                table: "NatjecajToZanimanjes",
                column: "ZanimanjeClassID");

            migrationBuilder.CreateIndex(
                name: "IX_PosaoToOpremas_OpremaClassID",
                table: "PosaoToOpremas",
                column: "OpremaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_PosaoToOpremas_PosaoClassID",
                table: "PosaoToOpremas",
                column: "PosaoClassID");

            migrationBuilder.CreateIndex(
                name: "IX_PosaoToZanimanjes_PosaoClassID",
                table: "PosaoToZanimanjes",
                column: "PosaoClassID");

            migrationBuilder.CreateIndex(
                name: "IX_PosaoToZanimanjes_ZanimanjeClassID",
                table: "PosaoToZanimanjes",
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
                name: "ArhivaNatjecaj");

            migrationBuilder.DropTable(
                name: "CheckBoxViewModel");

            migrationBuilder.DropTable(
                name: "CheckBoxViewModelOprema");

            migrationBuilder.DropTable(
                name: "Djelatnik");

            migrationBuilder.DropTable(
                name: "NatjecajToOpremas");

            migrationBuilder.DropTable(
                name: "NatjecajToZanimanjes");

            migrationBuilder.DropTable(
                name: "PosaoToOpremas");

            migrationBuilder.DropTable(
                name: "PosaoToZanimanjes");

            migrationBuilder.DropTable(
                name: "UslugaToOpremas");

            migrationBuilder.DropTable(
                name: "UslugaToZanimanjes");

            migrationBuilder.DropTable(
                name: "NatjecajViewModels");

            migrationBuilder.DropTable(
                name: "UslugaViewModel");

            migrationBuilder.DropTable(
                name: "Natjecaj");

            migrationBuilder.DropTable(
                name: "Posao");

            migrationBuilder.DropTable(
                name: "Oprema");

            migrationBuilder.DropTable(
                name: "UslugaClass");

            migrationBuilder.DropTable(
                name: "Zanimanje");
        }
    }
}
