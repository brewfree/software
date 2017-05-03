using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BrewFree.Data;
using BrewFree.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace BrewFree.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IList<UserReadModel>> GetListAsync()
        {
            var users = await context.Users.ToListAsync();

            return Mapper.Map<IList<UserReadModel>>(users);
        }

        public async Task<UserReadModel> GetAsync(string id)
        {
            var user = await context.Users.FindAsync(id);

            return Mapper.Map<UserReadModel>(user);
        }
    }
}
