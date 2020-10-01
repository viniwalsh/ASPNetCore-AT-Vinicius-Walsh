using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface IPoderService
    {
        Task<IEnumerable<PoderModel>> GetAllAsync();
        Task<PoderModel> GetByIdAsync(int id);
        Task<int> AddAsync(PoderHeroiCreateModel poderHeroiCreateModel);
        Task EditAsync(PoderModel poderModel);
        Task RemoveAsync(PoderModel poderModel);
    }
}
