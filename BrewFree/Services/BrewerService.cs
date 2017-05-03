using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrewFree.Data;
using BrewFree.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace BrewFree.Services
{
    public class BrewerService : IBrewerService
    {
        private readonly ApplicationDbContext context;

        public BrewerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IList<BrewerReadModel>> GetListByApplicationUserAsync(string applicationUserId)
        {
            var brewers = await context.Brewers.Where(x => x.ApplicationUserId == applicationUserId).ToListAsync();

            return Mapper.Map<IList<BrewerReadModel>>(brewers);
        }

        public async Task<BrewerReadModel> GetAsync(string id)
        {
            var brewer = await context.Brewers.FindAsync(id);

            return Mapper.Map<BrewerReadModel>(brewer);
        }
    }
}
