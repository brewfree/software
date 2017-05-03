using System.Collections.Generic;
using System.Threading.Tasks;
using BrewFree.ReadModels;

namespace BrewFree.Services
{
    public interface IUserService
    {
        Task<IList<UserReadModel>> GetListAsync();

        Task<UserReadModel> GetAsync(string id);
    }
}
