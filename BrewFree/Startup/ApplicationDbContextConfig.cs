using BrewFree.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace BrewFree
{
    public static class ApplicationDbContextConfig
    {
        public static void UseApplicationDbContext(this IApplicationBuilder app, ApplicationDbContext context)
        {
            context.Database.Migrate();

            SeedData.EnsureSeedData(context);
        }
    }
}
