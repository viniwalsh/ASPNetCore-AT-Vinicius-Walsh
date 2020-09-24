using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.Models
{
    public class Heroi
    {

        public int HeroiID { get; set; }
        [StringLength(150)]
        public string NomeCompleto { get; set; }
        [Required]
        [StringLength(150)]
        public string Codinome { get; set; }
        [StringLength(5)]
        public int Peso { get; set; }
        [StringLength(5)]
        public int Altura { get; set; }
        [Required]
        [StringLength(200)]
        public string ImagemUrl { get; set; }
        public int PoderId { get; set; }
        public virtual Poder Poder { get; set; }
    }
}
