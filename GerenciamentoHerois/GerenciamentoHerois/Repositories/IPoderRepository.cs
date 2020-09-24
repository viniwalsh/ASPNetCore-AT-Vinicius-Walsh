using GerenciamentoHerois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.Repositories
{
    public interface IPoderRepository
    {
        IEnumerable<Poder> Poderes { get; }
    }
}
