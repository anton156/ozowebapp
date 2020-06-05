using Microsoft.EntityFrameworkCore.Migrations;

namespace ozowebapp.Migrations
{
    public partial class AddArhivaNatjecaja : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArhivaNatjecaj");
        }
    }
}
