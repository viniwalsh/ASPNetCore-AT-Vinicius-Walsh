using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service
{
    public class HeroiService : IHeroiService
    {
        private readonly IHeroiRepository _heroiRepository;

        public HeroiService(
            IHeroiRepository heroiRepository)
        {
            _heroiRepository = heroiRepository;
        }

        public async Task<IEnumerable<HeroiModel>> GetAllAsync(string search)
        {
            return await _heroiRepository.GetAllAsync(search);
        }

        public async Task<HeroiModel> GetByIdAsync(int id)
        {
            return await _heroiRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(HeroiModel heroiModel)
        {
            var heroiId = await _heroiRepository.AddAsync(heroiModel);

            return heroiId;
        }

        public async Task EditAsync(HeroiModel heroiModel)
        {
            await _heroiRepository.EditAsync(heroiModel);
        }

        public async Task RemoveAsync(HeroiModel heroiModel)
        {
            await _heroiRepository.RemoveAsync(heroiModel);
        }
    }
}
