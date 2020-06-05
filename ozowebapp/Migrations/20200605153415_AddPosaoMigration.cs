using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ozowebapp.Migrations
{
    public partial class AddPosaoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kolicina",
                table: "Zanimanje",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "UslugaViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "UslugaViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lokacija",
                table: "UslugaViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxKolicina",
                table: "CheckBoxViewModelOprema",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModelOprema",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxKolicina",
                table: "CheckBoxViewModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModel",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxViewModelOprema_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModelOprema",
                column: "NatjecajViewModelNatjecajClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxViewModel_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModel",
                column: "NatjecajViewModelNatjecajClassID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CheckBoxViewModel_NatjecajViewModels_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModel",
                column: "NatjecajViewModelNatjecajClassID",
                principalTable: "NatjecajViewModels",
                principalColumn: "NatjecajClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckBoxViewModelOprema_NatjecajViewModels_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModelOprema",
                column: "NatjecajViewModelNatjecajClassID",
                principalTable: "NatjecajViewModels",
                principalColumn: "NatjecajClassID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckBoxViewModel_NatjecajViewModels_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckBoxViewModelOprema_NatjecajViewModels_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModelOprema");

            migrationBuilder.DropTable(
                name: "NatjecajToOpremas");

            migrationBuilder.DropTable(
                name: "NatjecajToZanimanjes");

            migrationBuilder.DropTable(
                name: "NatjecajViewModels");

            migrationBuilder.DropTable(
                name: "Posao");

            migrationBuilder.DropTable(
                name: "Natjecaj");

            migrationBuilder.DropIndex(
                name: "IX_CheckBoxViewModelOprema_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModelOprema");

            migrationBuilder.DropIndex(
                name: "IX_CheckBoxViewModel_NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModel");

            migrationBuilder.DropColumn(
                name: "MaxKolicina",
                table: "CheckBoxViewModelOprema");

            migrationBuilder.DropColumn(
                name: "NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModelOprema");

            migrationBuilder.DropColumn(
                name: "MaxKolicina",
                table: "CheckBoxViewModel");

            migrationBuilder.DropColumn(
                name: "NatjecajViewModelNatjecajClassID",
                table: "CheckBoxViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "Kolicina",
                table: "Zanimanje",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "UslugaViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "UslugaViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Lokacija",
                table: "UslugaViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
