using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IPoderRepository
    {
        Task<IEnumerable<PoderModel>> GetAllAsync();
        Task<PoderModel> GetByIdAsync(int id);
        Task<int> AddAsync(
            PoderModel poderModel);
        Task EditAsync(PoderModel poderModel);
        Task RemoveAsync(PoderModel poderModel);
    }
}
