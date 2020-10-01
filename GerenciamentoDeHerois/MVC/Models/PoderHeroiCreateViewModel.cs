using Domain.Model.Models;

namespace MVC.Models
{
    public class PoderHeroiCreateViewModel
    {
        public HeroiModel Heroi { get; set; }
        public PoderModel Poder { get; set; }

        public PoderHeroiCreateModel ToModel()
        {
            return new PoderHeroiCreateModel
            {
                Heroi = Heroi,
                Poder = Poder
            };
        }
    }
}
