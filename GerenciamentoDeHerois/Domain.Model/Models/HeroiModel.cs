using System;
using System.Collections.Generic;

namespace Domain.Model.Models
{
    public class HeroiModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Codinome { get; set; }
        public string ImageURL { get; set; }
        public DateTime Lancamento { get; set; }
        public List<PoderModel> Poderes { get; set; }
    }
}
