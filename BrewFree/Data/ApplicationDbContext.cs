using BrewFree.Data.Models;
using BrewFree.Data.Models.Lookups;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrewFree.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        #region Lookup

        public DbSet<BrewingMethod> BrewingMethods { get; set; }

        public DbSet<Style> Styles { get; set; }

        public DbSet<StyleTagAssociation> StyleTagAssociations { get; set; }

        public DbSet<StyleTag> StyleTags { get; set; }

        #endregion Lookup

        #region User

        public DbSet<Brewer> Brewers { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        #endregion User

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Security

            builder.Entity<IdentityRoleClaim<string>>().ForSqlServerToTable("RoleClaims", "Security");
            builder.Entity<IdentityRole>().ForSqlServerToTable("Roles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ForSqlServerToTable("UserClaims", "Security");
            builder.Entity<IdentityUserLogin<string>>().ForSqlServerToTable("UserLogins", "Security");
            builder.Entity<IdentityUserRole<string>>().ForSqlServerToTable("UserRoles", "Security");
            builder.Entity<ApplicationUser>().ForSqlServerToTable("Users", "Security");
            builder.Entity<IdentityUserToken<string>>().ForSqlServerToTable("UserTokens", "Security");

            #endregion Security

            #region Lookup

            builder.Entity<BrewingMethod>().ForSqlServerToTable("BrewingMethods", "Lookup");
            builder.Entity<StyleTag>().ForSqlServerToTable("StyleTags", "Lookup");
            builder.Entity<Style>().ForSqlServerToTable("Styles", "Lookup");
            builder.Entity<StyleTagAssociation>().ForSqlServerToTable("StyleTagAssociation", "Lookup");
            builder.Entity<StyleTagAssociation>().HasKey(x => new { x.StyleCode, x.StyleTagCode });
            builder.Entity<StyleTagAssociation>().HasOne(x => x.Style).WithMany(x => x.StyleTags);

            #endregion Lookup

            #region User

            builder.Entity<Brewer>().ForSqlServerToTable("Brewers", "User");
            builder.Entity<Recipe>().ForSqlServerToTable("Recipes", "User");

            #endregion User
        }
    }
}
