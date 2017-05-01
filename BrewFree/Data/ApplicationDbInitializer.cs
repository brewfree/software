using System.Linq;
using BrewFree.Data.Models.Lookups;
using Microsoft.EntityFrameworkCore;

namespace BrewFree.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (!context.BrewTypes.Any())
            {
                SeedLookups(context);
            }
        }

        private static void SeedLookups(ApplicationDbContext context)
        {
            context.BrewTypes.Add(new BrewType {Name = "All Grain"});
            context.BrewTypes.Add(new BrewType {Name = "Extract"});
            context.BrewTypes.Add(new BrewType {Name = "Partial Mash"});
        }
    }
}
