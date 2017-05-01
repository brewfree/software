using System.Collections.Generic;
using System.Threading.Tasks;
using BrewFree.ReadModels;

namespace BrewFree.Services
{
    public interface IBrewerService
    {
        Task<IList<BrewerReadModel>> GetListByApplicationUserAsync(string id);
    }
}