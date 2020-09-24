using GerenciamentoHerois.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoHerois.Components
{
    public class PoderMenu : ViewComponent
    {
        private readonly IPoderRepository _poderRepository;

        public PoderMenu(IPoderRepository poderRepository)
        {
            _poderRepository = poderRepository;
        }

        public IViewComponentResult Invoke()
        {
            var poderes = _poderRepository.Poderes.OrderBy(c => c.TipoPoder);

            return View(poderes);
        }
    }
}
