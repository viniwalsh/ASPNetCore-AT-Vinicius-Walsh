using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoHerois.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poderes",
                columns: table => new
                {
                    PoderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPoder = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poderes", x => x.PoderId);
                });

            migrationBuilder.CreateTable(
                name: "Herois",
                columns: table => new
                {
                    HeroiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(maxLength: 150, nullable: true),
                    Codinome = table.Column<string>(maxLength: 150, nullable: false),
                    Peso = table.Column<int>(maxLength: 5, nullable: false),
                    Altura = table.Column<int>(maxLength: 5, nullable: false),
                    ImagemUrl = table.Column<string>(maxLength: 200, nullable: false),
                    PoderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herois", x => x.HeroiID);
                    table.ForeignKey(
                        name: "FK_Herois_Poderes_PoderId",
                        column: x => x.PoderId,
                        principalTable: "Poderes",
                        principalColumn: "PoderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Herois_PoderId",
                table: "Herois",
                column: "PoderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Herois");

            migrationBuilder.DropTable(
                name: "Poderes");
        }
    }
}
