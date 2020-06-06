using Microsoft.EntityFrameworkCore.Migrations;

namespace ozowebapp.Migrations
{
    public partial class initiald : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArhivaNatjecajToOpremas",
                columns: table => new
                {
                    ArhivaNatjecajToOpremaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArhivaNatjecajClassID = table.Column<int>(nullable: false),
                    OpremaClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArhivaNatjecajToOpremas", x => x.ArhivaNatjecajToOpremaID);
                    table.ForeignKey(
                        name: "FK_ArhivaNatjecajToOpremas_ArhivaNatjecaj_ArhivaNatjecajClassID",
                        column: x => x.ArhivaNatjecajClassID,
                        principalTable: "ArhivaNatjecaj",
                        principalColumn: "ArhivaNatjecajClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArhivaNatjecajToOpremas_Oprema_OpremaClassID",
                        column: x => x.OpremaClassID,
                        principalTable: "Oprema",
                        principalColumn: "OpremaClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArhivaNatjecajToZanimanjes",
                columns: table => new
                {
                    ArhivaNatjecajToZanimanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArhivaNatjecajClassID = table.Column<int>(nullable: false),
                    ZanimanjeClassID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArhivaNatjecajToZanimanjes", x => x.ArhivaNatjecajToZanimanjeID);
                    table.ForeignKey(
                        name: "FK_ArhivaNatjecajToZanimanjes_ArhivaNatjecaj_ArhivaNatjecajClassID",
                        column: x => x.ArhivaNatjecajClassID,
                        principalTable: "ArhivaNatjecaj",
                        principalColumn: "ArhivaNatjecajClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArhivaNatjecajToZanimanjes_Zanimanje_ZanimanjeClassID",
                        column: x => x.ZanimanjeClassID,
                        principalTable: "Zanimanje",
                        principalColumn: "ZanimanjeClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaNatjecajToOpremas_ArhivaNatjecajClassID",
                table: "ArhivaNatjecajToOpremas",
                column: "ArhivaNatjecajClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaNatjecajToOpremas_OpremaClassID",
                table: "ArhivaNatjecajToOpremas",
                column: "OpremaClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaNatjecajToZanimanjes_ArhivaNatjecajClassID",
                table: "ArhivaNatjecajToZanimanjes",
                column: "ArhivaNatjecajClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ArhivaNatjecajToZanimanjes_ZanimanjeClassID",
                table: "ArhivaNatjecajToZanimanjes",
                column: "ZanimanjeClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArhivaNatjecajToOpremas");

            migrationBuilder.DropTable(
                name: "ArhivaNatjecajToZanimanjes");
        }
    }
}
