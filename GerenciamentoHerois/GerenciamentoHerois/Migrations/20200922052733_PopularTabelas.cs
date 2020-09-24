using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoHerois.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Herois(PoderID, NomeCompleto, Codinome, Peso, Altura, ImagemUrl) VALUES(SELECT PoderID FROM Poderes Where TipoPoder='Armas', 'Bruce Wayne', 'Batman', '95', '‎1,88', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fpt.wikipedia.org%2Fwiki%2FBatman&psig=AOvVaw1M5lghhGy_lyimcXK-OOqV&ust=1600839320503000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCIDN4amF_OsCFQAAAAAdAAAAABAD')");
            migrationBuilder.Sql("INSERT INTO Herois(PoderID, NomeCompleto, Codinome, Peso, Altura, ImagemUrl) VALUES(SELECT PoderID FROM Poderes Where TipoPoder='Indestrutivel', 'Kal-El', 'SuperHomem', '95', '‎1,92', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fpt.wikipedia.org%2Fwiki%2FSuperman&psig=AOvVaw0HkW6UqQAGqwvUUIMIi47t&ust=1600839547520000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKj88pWG_OsCFQAAAAAdAAAAABAD')");
            migrationBuilder.Sql("INSERT INTO Herois(PoderID, NomeCompleto, Codinome, Peso, Altura, ImagemUrl) VALUES(SELECT PoderID FROM Poderes Where TipoPoder='Armaduras', 'Antony Edward 'Tony' Stark', 'Homem de Ferro', '90', '‎1,85', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fpt.wikipedia.org%2Fwiki%2FSuperman&psig=AOvVaw0HkW6UqQAGqwvUUIMIi47t&ust=1600839547520000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKj88pWG_OsCFQAAAAAdAAAAABAD')");

            migrationBuilder.Sql("INSERT INTO Poderes(TipoPoder, Descricao) VALUES('Armas', 'Perito em Armas')");
            migrationBuilder.Sql("INSERT INTO Poderes(TipoPoder, Descricao) VALUES('Indestrutivel', 'Resistente')");
            migrationBuilder.Sql("INSERT INTO Poderes(TipoPoder, Descricao) VALUES('Armaduras', 'Armaduras de Batalha')");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Herois");
            migrationBuilder.Sql("DELETE FROM Poderes");
        }
    }
}
