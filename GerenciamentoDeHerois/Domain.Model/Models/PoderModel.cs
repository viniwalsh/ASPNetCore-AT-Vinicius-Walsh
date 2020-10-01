using System;

namespace Domain.Model.Models
{
    public class PoderModel
    {
        public int Id { get; set; }
        public string Poder { get; set; }
        public string Descricao { get; set; }

        public int HeroiId { get; set; }
        public HeroiModel Heroi { get; set; }
    }
}
