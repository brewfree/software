using System;
using System.Collections.Generic;
using System.Linq;
using BrewFree.Data.Constants;
using BrewFree.Data.Models;
using BrewFree.Data.Models.Lookups;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BrewFree.Data
{
    public class SeedData
    {
        internal static void EnsureSeedData(ApplicationDbContext context)
        {
            if (!SeedDataExists(context))
            {
                Seed(context);
            }
        }

        internal static void Seed(ApplicationDbContext context)
        {
            // roles
            context.Roles.Add(new IdentityRole(RoleType.Admin));

            // system user
            var systemId = Guid.Empty.ToString();
            context.Users.Add(new ApplicationUser { Id = systemId, Email = "support@brewfree.org", EmailConfirmed = true });

            // system brewer
            context.Brewers.Add(new Brewer { Id = Guid.NewGuid().ToString(), ApplicationUserId = systemId, Name = "Brew Free" });

            // style guide
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015", TypeCode = StyleTagType.StyleGuide, Name = "BJCP 2015", Description = "BEER JUDGE CERTIFICATION PROGRAM 2015" });

            // style family
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.ipa-family", TypeCode = StyleTagType.StyleFamily, Name = "IPA", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.brown-ale-family", TypeCode = StyleTagType.StyleFamily, Name = "Brown Ale", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-ale-family", TypeCode = StyleTagType.StyleFamily, Name = "Pale Ale", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-lager-family", TypeCode = StyleTagType.StyleFamily, Name = "Pale Lager", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pilsner-family", TypeCode = StyleTagType.StyleFamily, Name = "Pilsner", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.amber-ale-family", TypeCode = StyleTagType.StyleFamily, Name = "Amber Ale", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.amber-lager-family", TypeCode = StyleTagType.StyleFamily, Name = "Amber Lager", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.dark-lager-family", TypeCode = StyleTagType.StyleFamily, Name = "Dark Lager", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.porter-family", TypeCode = StyleTagType.StyleFamily, Name = "Porter", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.stout-family", TypeCode = StyleTagType.StyleFamily, Name = "Stout", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.bock-family", TypeCode = StyleTagType.StyleFamily, Name = "Bock", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.strong-ale-family", TypeCode = StyleTagType.StyleFamily, Name = "Strong Ale", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.wheat-beer-family", TypeCode = StyleTagType.StyleFamily, Name = "Wheat Beer", Description = "" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.specialty-beer", TypeCode = StyleTagType.StyleFamily, Name = "Speciality Beer", Description = "" });

            // color family
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color", TypeCode = StyleTagType.StyleColorFamily, Name = "Pale", Description = "Straw to gold" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.amber-color", TypeCode = StyleTagType.StyleColorFamily, Name = "Amber", Description = "Amber to copper-brown" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.dark-color", TypeCode = StyleTagType.StyleColorFamily, Name = "Dark", Description = "Dark brown to black" });

            // color
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.straw", TypeCode = StyleTagType.StyleColor, Name = "Straw", Description = "SRM 2-3" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.yellow", TypeCode = StyleTagType.StyleColor, Name = "Yellow", Description = "SRM 3-4" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.gold", TypeCode = StyleTagType.StyleColor, Name = "Gold", Description = "SRM 5-6" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.amber", TypeCode = StyleTagType.StyleColor, Name = "Amber", Description = "SRM 6-9" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.deep-amber", TypeCode = StyleTagType.StyleColor, Name = "Deep Amber/Light Copper", Description = "SRM 10-14" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.copper", TypeCode = StyleTagType.StyleColor, Name = "Copper", Description = "SRM 14-17" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.deep-copper", TypeCode = StyleTagType.StyleColor, Name = "Deep Copper/Light Brown", Description = "SRM 17-18" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.brown", TypeCode = StyleTagType.StyleColor, Name = "Brown", Description = "SRM 19-22" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.dark-brown", TypeCode = StyleTagType.StyleColor, Name = "Dark Brown", Description = "SRM 22-30" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.very-dark-brown", TypeCode = StyleTagType.StyleColor, Name = "Very Dark Brown", Description = "SRM 30-35" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.black", TypeCode = StyleTagType.StyleColor, Name = "Black", Description = "SRM 30+" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color.black-opaque", TypeCode = StyleTagType.StyleColor, Name = "Black, Opaque", Description = "SRM 40+" });

            // style
            context.Styles.Add(new Style
            {
                Code = "bjcp-2015.american-light-lager",
                Name = "American Light Lager",
                OriginalGravityMinimum = 2.8m,
                OriginalGravityMaximum = 4.2m,
                Description = "Highly carbonated, very light-bodied, nearly flavorless lager designed to be consumed very cold. Very refreshing and thirst quenching.",
                StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-light-lager", StyleTagCode = "bjcp-2015.pale-lager-family" } }
            });

            context.SaveChanges();
        }

        internal static bool SeedDataExists(ApplicationDbContext context)
        {
            return context.Users.Any();
        }
    }
}
