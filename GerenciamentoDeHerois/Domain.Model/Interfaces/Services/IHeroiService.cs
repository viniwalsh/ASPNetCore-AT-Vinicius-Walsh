﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface IHeroiService
    {
        Task<IEnumerable<HeroiModel>> GetAllAsync(string search);
        Task<HeroiModel> GetByIdAsync(int id);
        Task<int> AddAsync(HeroiModel heroiModel);
        Task EditAsync(HeroiModel heroiModel);
        Task RemoveAsync(HeroiModel heroiModel);
    }
}
