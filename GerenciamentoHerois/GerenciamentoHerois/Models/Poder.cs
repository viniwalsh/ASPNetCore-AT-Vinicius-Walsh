using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.Models
{
    public class Poder
    {
        public int PoderId { get; set; }
        [Required]
        [StringLength(100)]
        public string TipoPoder { get; set; }
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
        public List<Heroi> Herois { get; set; }
    }
}
