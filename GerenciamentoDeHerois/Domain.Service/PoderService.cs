using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Context;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;


namespace Domain.Service
{
    public class PoderService : IPoderService
    {
        private readonly IAdoNetScopedContext _adoNetScopedContext;
        private readonly IHeroiRepository _heroiRepository;
        private readonly IPoderRepository _poderRepository;

        public PoderService(
            IAdoNetScopedContext adoNetScopedContext,
            IHeroiRepository heroiRepository,
            IPoderRepository poderRepository)
        {
            _adoNetScopedContext = adoNetScopedContext;
            _heroiRepository = heroiRepository;
            _poderRepository = poderRepository;
        }

        public async Task<IEnumerable<PoderModel>> GetAllAsync()
        {
            return await _poderRepository.GetAllAsync();
        }

        public async Task<PoderModel> GetByIdAsync(int id)
        {
            return await _poderRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(PoderHeroiCreateModel poderHeroiCreateModel)
        {
            if (poderHeroiCreateModel.Poder.HeroiId > 0)
            {
                return await _poderRepository.AddAsync(poderHeroiCreateModel.Poder);
            }

            await _adoNetScopedContext.BeginTransactionAsync();

            var heroiId = await _heroiRepository.AddAsync(poderHeroiCreateModel.Heroi);

            poderHeroiCreateModel.Poder.HeroiId = heroiId;

            var poderId =
                await _poderRepository.AddAsync(poderHeroiCreateModel.Poder);

            await _adoNetScopedContext.CommitAsync();

            return poderId;
        }

        public async Task EditAsync(PoderModel poderModel)
        {
            await _poderRepository.EditAsync(poderModel);
        }

        public async Task RemoveAsync(PoderModel poderModel)
        {
            await _poderRepository.RemoveAsync(poderModel);
        }
    }
}
