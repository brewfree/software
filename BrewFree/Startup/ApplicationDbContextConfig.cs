using System.Linq;
using BrewFree.Data;
using BrewFree.Data.Constants;
using BrewFree.Data.Models.Lookups;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace BrewFree
{
    public static class ApplicationDbContextConfig
    {
        public static void UseApplicationDbContext(this IApplicationBuilder app, ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (!context.StyleTags.Any())
            {
                SeedLookups(context);
            }
        }

        private static void SeedLookups(ApplicationDbContext context)
        {
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015", TypeCode = StyleTagType.StyleGuide, Name = "BJCP 2015", Description = "BEER JUDGE CERTIFICATION PROGRAM 2015"});
            
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

            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.pale-color", TypeCode = StyleTagType.StyleColorFamily, Name = "Pale", Description = "Straw to gold" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.amber-color", TypeCode = StyleTagType.StyleColorFamily, Name = "Amber", Description = "Amber to copper-brown" });
            context.StyleTags.Add(new StyleTag { Code = "bjcp-2015.dark-color", TypeCode = StyleTagType.StyleColorFamily, Name = "Dark", Description = "Dark brown to black" });
            
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

            //context.BrewingMethods.Add(new BrewingMethod {Code = "all-grain", Name = "All Grain"});
            //context.BrewingMethods.Add(new BrewingMethod {Code = "extract", Name = "Extract"});
            //context.BrewingMethods.Add(new BrewingMethod {Code = "partial-mash", Name = "Partial Mash"});

            //context.StyleGuides.Add(new StyleGuide
            //{
            //    Code = "bjcp-2015",
            //    Name = "BJCP 2015",
            //    Description = "BEER JUDGE CERTIFICATION PROGRAM 2015"
            //});

            //context.StyleFamilies.Add(new StyleFamily {Code = "ipa-family", StyleGuideCode = "bjcp-2015", Name = "IPA"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "brown-ale-family", StyleGuideCode = "bjcp-2015", Name = "Brown Ale"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "pale-ale-family", StyleGuideCode = "bjcp-2015", Name = "Pale Ale"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "pale-lager-family", StyleGuideCode = "bjcp-2015", Name = "Pale Lager"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "pilsner-family", StyleGuideCode = "bjcp-2015", Name = "Pilsner"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "amber-ale-family", StyleGuideCode = "bjcp-2015", Name = "Amber Ale"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "amber-lager-family", StyleGuideCode = "bjcp-2015", Name = "Amber Lager"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "dark-lager-family", StyleGuideCode = "bjcp-2015", Name = "Dark Lager"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "porter-family", StyleGuideCode = "bjcp-2015", Name = "Porter"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "stout-family", StyleGuideCode = "bjcp-2015", Name = "Stout"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "bock-family", StyleGuideCode = "bjcp-2015", Name = "Bock"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "strong-ale-family", StyleGuideCode = "bjcp-2015", Name = "Strong Ale"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "wheat-beer-family", StyleGuideCode = "bjcp-2015", Name = "Wheat Beer"});
            //context.StyleFamilies.Add(new StyleFamily {Code = "specialty-beer", StyleGuideCode = "bjcp-2015", Name = "Speciality Beer"});

            //context.StyleColorFamilies.Add(new StyleColorFamily {Code = "pale-color", Name = "Pale"});
            //context.StyleColorFamilies.Add(new StyleColorFamily {Code = "amber-color", Name = "Amber"});
            //context.StyleColorFamilies.Add(new StyleColorFamily {Code = "dark-color", Name = "Dark"});

            //context.StyleColors.Add(new StyleColor { Code = "color-straw", StyleColorFamilyCode = "pale-color", Name = "Straw", ColorMinimum = 2.0m, ColorMaximum = 3.0m});
            //context.StyleColors.Add(new StyleColor { Code = "color-yellow", StyleColorFamilyCode = "pale-color", Name = "Yellow", ColorMinimum = 3.0m, ColorMaximum = 4.0m});
            //context.StyleColors.Add(new StyleColor { Code = "color-gold", StyleColorFamilyCode = "pale-color", Name = "Gold", ColorMinimum = 5.0m, ColorMaximum = 6.0m});
            //context.StyleColors.Add(new StyleColor { Code = "AMBER", StyleGuideCode = "bjcp-2015" Tag = "amber-color",  Name = "Amber", ColorMinimum = 6.0m, ColorMaximum = 9.0m});
            //context.StyleColors.Add(new StyleColor { Code = "DEEPAMBER", StyleGuideCode = "bjcp-2015" Tag = "amber-color",  Name = "Deep amber/light copper", ColorMinimum = 10.0m, ColorMaximum = 14.0m});
            //context.StyleColors.Add(new StyleColor { Code = "COPPERBROWN", StyleGuideCode = "bjcp-2015" Tag = "amber-color",  Name = "Deep copper/light brown", ColorMinimum = 17.0m, ColorMaximum = 18.0m});
            //context.StyleColors.Add(new StyleColor { Code = "BROWN", StyleGuideCode = "bjcp-2015" Tag = "amber-color",  Name = "Brown", ColorMinimum = 19.0m, ColorMaximum = 22.0m});
            //context.StyleColors.Add(new StyleColor { Code = "DARKBROWN", StyleGuideCode = "bjcp-2015" Tag = "dark-color",  Name = "Dark Brown", ColorMinimum = 22.0m, ColorMaximum = 30.0m});
            //context.StyleColors.Add(new StyleColor { Code = "XDARKBROWN", StyleGuideCode = "bjcp-2015" Tag = "dark-color",  Name = "Very Dark Brown", ColorMinimum = 30.0m, ColorMaximum = 35.0m});
            //context.StyleColors.Add(new StyleColor { Code = "BLACK", StyleGuideCode = "bjcp-2015" Tag = "dark-color",  Name = "Black", ColorMinimum = 30.0m, ColorMaximum = null});
            //context.StyleColors.Add(new StyleColor { Code = "BLACKOPAQUE", StyleGuideCode = "bjcp-2015" Tag = "dark-color",  Name = "Black, opaque", ColorMinimum = 40.0m, ColorMaximum = null});

            //context.Styles.Add(new Style {StyleGuideCode = "bjcp-2015", Code = "", Description = ""})

            context.SaveChanges();
        }
    }
}
