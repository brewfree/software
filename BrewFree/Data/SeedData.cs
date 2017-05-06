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
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-light-lager", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-lager",
				Name = "American Lager",
				OriginalGravityMinimum = 4.2m,
				OriginalGravityMaximum = 5.3m,
				Description = "A very pale, highly-carbonated, light-bodied, well-attenuated lager with a very neutral flavor profile and low bitterness. Served very cold, it can be a very refreshing and thirst quenching drink.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-lager", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.cream-ale",
				Name = "Cream Ale",
				OriginalGravityMinimum = 4.2m,
				OriginalGravityMaximum = 5.6m,
				Description = "A clean, well-attenuated, flavorful American “lawnmower” beer. Easily drinkable and refreshing, with more character than typical American lagers.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.cream-ale", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-wheat-beer",
				Name = "American Wheat Beer",
				OriginalGravityMinimum = 4m,
				OriginalGravityMaximum = 5.5m,
				Description = "Refreshing wheat beers that can display more hop character and less yeast character than their German cousins. A clean fermentation character allows bready, doughy, or grainy wheat flavors to be complemented by hop flavor and bitterness rather than yeast qualities.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-wheat-beer", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.international-pale-lager",
				Name = "International Pale Lager",
				OriginalGravityMinimum = 4.6m,
				OriginalGravityMaximum = 6m,
				Description = "A highly-attenuated pale lager without strong flavors, typically well-balanced and highly carbonated. Served cold, it is refreshing and thirst-quenching.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.international-pale-lager", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.international-amber-lager",
				Name = "International Amber Lager",
				OriginalGravityMinimum = 4.6m,
				OriginalGravityMaximum = 6m,
				Description = "A well-attenuated malty amber lager with an interesting caramel or toast quality and restrained bitterness. Usually fairly well-attenuated, often with an adjunct quality. Smooth, easily-drinkable lager character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.international-amber-lager", StyleTagCode = "bjcp-2015.amber-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.international-dark-lager",
				Name = "International Dark Lager",
				OriginalGravityMinimum = 4.2m,
				OriginalGravityMaximum = 6m,
				Description = "A darker and somewhat sweeter version of international pale lager with a little more body and flavor, but equally restrained in bitterness. The low bitterness leaves the malt as the primary flavor element, and the low hop levels provide very little in the way of balance.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.international-dark-lager", StyleTagCode = "bjcp-2015.dark-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.czech-pale-lager",
				Name = "Czech Pale Lager",
				OriginalGravityMinimum = 3m,
				OriginalGravityMaximum = 4.1m,
				Description = "A lighter-bodied, rich, refreshing, hoppy, bitter pale Czech lager having the familiar flavors of the stronger Czech Premium Pale Lager (Pilsner-type) beer but in a lower alcohol, lighter-bodied, and slightly less intense format.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.czech-pale-lager", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.czech-premium-pale-lager",
				Name = "Czech Premium Pale Lager",
				OriginalGravityMinimum = 4.2m,
				OriginalGravityMaximum = 5.8m,
				Description = "Rich, characterful, pale Czech lager, with considerable malt and hop character and a long, rounded finish. Complex yet well-balanced and refreshing. The malt flavors are complex for a Pilsner-type beer, and the bitterness is strong but clean and without harshness, which gives a rounded impression that enhances drinkability.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.czech-premium-pale-lager", StyleTagCode = "bjcp-2015.pilsner-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.czech-amber-lager",
				Name = "Czech Amber Lager",
				OriginalGravityMinimum = 4.4m,
				OriginalGravityMaximum = 5.8m,
				Description = "Malt-driven amber Czech lager with hop character that can vary from low to quite significant. The malt flavors can vary quite a bit, leading to different interpretations ranging from drier, bready, and slightly biscuity to sweeter and somewhat caramelly.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.czech-amber-lager", StyleTagCode = "bjcp-2015.amber-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.czech-dark-lager",
				Name = "Czech Dark Lager",
				OriginalGravityMinimum = 4.4m,
				OriginalGravityMaximum = 5.8m,
				Description = "A rich, dark, malty Czech lager with a roast character that can vary from almost absent to quite prominent. Malty with an interesting and complex flavor profile, with variable levels of hopping providing a range of possible interpretations.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.czech-dark-lager", StyleTagCode = "bjcp-2015.dark-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.munich-helles",
				Name = "Munich Helles",
				OriginalGravityMinimum = 4.7m,
				OriginalGravityMaximum = 5.4m,
				Description = "A clean, malty, gold-colored German lager with a smooth grainy-sweet malty flavor and a soft, dry finish. Subtle spicy, floral, or herbal hops and restrained bitterness help keep the balance malty but not sweet, which helps make this beer a refreshing, everyday drink.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.munich-helles", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.festbier",
				Name = "Festbier",
				OriginalGravityMinimum = 5.8m,
				OriginalGravityMaximum = 6.3m,
				Description = "A smooth, clean, pale German lager with a moderately strong malty flavor and a light hop character. Deftly balances strength and drinkability, with a palate impression and finish that encourages drinking. Showcases elegant German malt flavors without becoming too heavy or filling.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.festbier", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.helles-bock",
				Name = "Helles Bock",
				OriginalGravityMinimum = 6.3m,
				OriginalGravityMaximum = 7.4m,
				Description = "A relatively pale, strong, malty German lager beer with a nicely attenuated finish that enhances drinkability. The hop character is generally more apparent than in other bocks.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.helles-bock", StyleTagCode = "bjcp-2015.bock-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.german-leichtbier",
				Name = "German Leichtbier",
				OriginalGravityMinimum = 2.4m,
				OriginalGravityMaximum = 3.6m,
				Description = "A pale, highly-attenuated, light-bodied German lager with lower alcohol and calories than normal-strength beers. Moderately bitter with noticeable malt and hop flavors, the beer is still interesting to drink.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.german-leichtbier", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.kölsch",
				Name = "Kölsch",
				OriginalGravityMinimum = 4.4m,
				OriginalGravityMaximum = 5.2m,
				Description = "A clean, crisp, delicately-balanced beer usually with a very subtle fruit and hop character. Subdued maltiness throughout leads into a pleasantly well-attenuated and refreshing finish. Freshness makes a huge difference with this beer, as the delicate character can fade quickly with age. Brilliant clarity is characteristic.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.kölsch", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.german-helles-exportbier",
				Name = "German Helles Exportbier",
				OriginalGravityMinimum = 4.8m,
				OriginalGravityMaximum = 6m,
				Description = "A pale, well-balanced, smooth German lager that is slightly stronger than the average beer with a moderate body and a mild, aromatic hop and malt character. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.german-helles-exportbier", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.german-pils",
				Name = "German Pils",
				OriginalGravityMinimum = 4.4m,
				OriginalGravityMaximum = 5.2m,
				Description = "A light-bodied, highly-attenuated, gold-colored, bottom-fermented bitter German beer showing excellent head retention and an elegant, floral hop aroma. Crisp, clean, and refreshing, a German Pils showcases the finest quality German malt and hops.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.german-pils", StyleTagCode = "bjcp-2015.pilsner-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.märzen",
				Name = "Märzen",
				OriginalGravityMinimum = 5.8m,
				OriginalGravityMaximum = 6.3m,
				Description = "An elegant, malty German amber lager with a clean, rich, toasty and bready malt flavor, restrained bitterness, and a dry finish that encourages another drink. The overall malt impression is soft, elegant, and complex, with a rich aftertaste that is never cloying or heavy. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.märzen", StyleTagCode = "bjcp-2015.amber-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.rauchbier",
				Name = "Rauchbier",
				OriginalGravityMinimum = 4.8m,
				OriginalGravityMaximum = 6m,
				Description = "An elegant, malty German amber lager with a balanced, complementary beechwood smoke character. Toasty-rich malt in aroma and flavor, restrained bitterness, low to high smoke flavor, clean fermentation profile, and an attenuated finish are characteristic. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.rauchbier", StyleTagCode = "bjcp-2015.amber-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.dunkles-bock",
				Name = "Dunkles Bock",
				OriginalGravityMinimum = 6.3m,
				OriginalGravityMaximum = 7.2m,
				Description = "A dark, strong, malty German lager beer that emphasizes the malty-rich and somewhat toasty qualities of continental malts without being sweet in the finish.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.dunkles-bock", StyleTagCode = "bjcp-2015.bock-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.vienna-lager",
				Name = "Vienna Lager",
				OriginalGravityMinimum = 4.7m,
				OriginalGravityMaximum = 5.5m,
				Description = "A moderate-strength amber lager with a soft, smooth maltiness and moderate bitterness, yet finishing relatively dry. The malt flavor is clean, bready-rich, and somewhat toasty, with an elegant impression derived from quality base malts and process, not specialty malts and adjuncts.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.vienna-lager", StyleTagCode = "bjcp-2015.amber-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.altbier",
				Name = "Altbier",
				OriginalGravityMinimum = 4.3m,
				OriginalGravityMaximum = 5.5m,
				Description = "A well-balanced, well-attenuated, bitter yet malty, clean, and smooth, amber- to copper-colored German beer. The bitterness is balanced by the malt richness, but the malt intensity and character can range from moderate to high (the bitterness increases with the malt richness). ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.altbier", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.pale-kellerbier",
				Name = "Pale Kellerbier",
				OriginalGravityMinimum = 4.7m,
				OriginalGravityMaximum = 5.4m,
				Description = "A young, fresh Helles, so while still a malty, fully-attenuated Pils malt showcase, the hop character (aroma, flavor and bitterness) is more pronounced, and the beer is cloudy, often with some level of diacetyl, and possibly has some green apple and/or other yeast-derived notes. As with the traditional Helles, the Keller version is still a beer intended to be drunk by the liter, so overall it should remain a light, refreshing, easy drinking golden lager.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.pale-kellerbier", StyleTagCode = "bjcp-2015.pale-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.amber-kellerbier",
				Name = "Amber Kellerbier",
				OriginalGravityMinimum = 4.8m,
				OriginalGravityMaximum = 5.4m,
				Description = "A young, unfiltered, and unpasteurized beer that is between a Helles and Märzen in color, spicier in the hops with greater attenuation. Interpretations range in color and balance, but remain in the drinkable 4.8% ABV neighborhood. Balance ranges from the dry, spicy and pale-colored interpretations by St. Georgen and Löwenbräu of Buttenheim, to darker and maltier interpretations in the Fränkische Schweiz. This style is above all a method of producing simple drinkable beers for neighbors out of local ingredients to be served fresh. Balance with a focus on drinkability and digestibility is important.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.amber-kellerbier", StyleTagCode = "bjcp-2015.amber-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.munich-dunkel",
				Name = "Munich Dunkel",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 5.6m,
				Description = "Characterized by depth, richness and complexity typical of darker Munich malts with the accompanying Maillard products. Deeply bready-toasty, often with chocolate-like flavors in the freshest examples, but never harsh, roasty, or astringent; a decidedly malt-balanced beer, yet still easily drinkable.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.munich-dunkel", StyleTagCode = "bjcp-2015.dark-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.schwarzbier",
				Name = "Schwarzbier",
				OriginalGravityMinimum = 4.4m,
				OriginalGravityMaximum = 5.4m,
				Description = "A dark German lager that balances roasted yet smooth malt flavors with moderate hop bitterness. The lighter body, dryness, and lack of a harsh, burnt, or heavy aftertaste helps make this beer quite drinkable.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.schwarzbier", StyleTagCode = "bjcp-2015.dark-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.doppelbock",
				Name = "Doppelbock",
				OriginalGravityMinimum = 7m,
				OriginalGravityMaximum = 10m,
				Description = "A strong, rich, and very malty German lager that can have both pale and dark variants. The darker versions have more richly-developed, deeper malt flavors, while the paler versions have slightly more hops and dryness.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.doppelbock", StyleTagCode = "bjcp-2015.bock-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.eisbock",
				Name = "Eisbock",
				OriginalGravityMinimum = 9m,
				OriginalGravityMaximum = 14m,
				Description = "A strong, full-bodied, rich, and malty dark German lager often with a viscous quality and strong flavors. Even though flavors are concentrated, the alcohol should be smooth and warming, not burning. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.eisbock", StyleTagCode = "bjcp-2015.bock-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.baltic-porter",
				Name = "Baltic Porter",
				OriginalGravityMinimum = 6.5m,
				OriginalGravityMaximum = 9.5m,
				Description = "A Baltic Porter often has the malt flavors reminiscent of an English porter and the restrained roast of a schwarzbier, but with a higher OG and alcohol content than either. Very complex, with multi-layered malt and dark fruit flavors.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.baltic-porter", StyleTagCode = "bjcp-2015.porter-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.weissbier",
				Name = "Weissbier",
				OriginalGravityMinimum = 4.3m,
				OriginalGravityMaximum = 5.6m,
				Description = "A pale, refreshing German wheat beer with high carbonation, dry finish, a fluffy mouthfeel, and a distinctive banana-and-clove yeast character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.weissbier", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.dunkles-weissbier",
				Name = "Dunkles Weissbier",
				OriginalGravityMinimum = 4.3m,
				OriginalGravityMaximum = 5.6m,
				Description = "A moderately dark German wheat beer with a distinctive banana-and-clove yeast character, supported by a toasted bread or caramel malt flavor. Highly carbonated and refreshing, with a creamy, fluffy texture and light finish that encourages drinking.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.dunkles-weissbier", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.weizenbock",
				Name = "Weizenbock",
				OriginalGravityMinimum = 6.5m,
				OriginalGravityMaximum = 9m,
				Description = "A strong, malty, fruity, wheat-based ale combining the best malt and yeast flavors of a weissbier (pale or dark) with the malty-rich flavor, strength, and body of a Dunkles Bock or Doppelbock.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.weizenbock", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.ordinary-bitter",
				Name = "Ordinary Bitter",
				OriginalGravityMinimum = 3.2m,
				OriginalGravityMaximum = 3.8m,
				Description = "Low gravity, low alcohol levels, and low carbonation make this an easy-drinking session beer. The malt profile can vary in flavor and intensity, but should never override the overall bitter impression. Drinkability is a critical component of the style ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.ordinary-bitter", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.best-bitter",
				Name = "Best Bitter",
				OriginalGravityMinimum = 3.8m,
				OriginalGravityMaximum = 4.6m,
				Description = "A flavorful, yet refreshing, session beer. Some examples can be more malt balanced, but this should not override the overall bitter impression. Drinkability is a critical component of the style.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.best-bitter", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.strong-bitter",
				Name = "Strong Bitter",
				OriginalGravityMinimum = 4.6m,
				OriginalGravityMaximum = 6.2m,
				Description = "An average-strength to moderately-strong British bitter ale. The balance may be fairly even between malt and hops to somewhat bitter. Drinkability is a critical component of the style. A rather broad style that allows for considerable interpretation by the brewer.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.strong-bitter", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.british-golden-ale",
				Name = "British Golden Ale",
				OriginalGravityMinimum = 3.8m,
				OriginalGravityMaximum = 5m,
				Description = "A hop-forward, average-strength to moderately-strong pale bitter. Drinkability and a refreshing quality are critical components of the style. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.british-golden-ale", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.australian-sparkling-ale",
				Name = "Australian Sparkling Ale",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 6m,
				Description = "Smooth and balanced, all components merge together with similar intensities. Moderate flavors showcasing Australian ingredients. Large flavor dimension. Very drinkable, suited to a hot climate. Relies on yeast character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.australian-sparkling-ale", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.english-ipa",
				Name = "English IPA",
				OriginalGravityMinimum = 5m,
				OriginalGravityMaximum = 7.5m,
				Description = "A hoppy, moderately-strong, very well-attenuated pale British ale with a dry finish and a hoppy aroma and flavor. Classic British ingredients provide the best flavor profile. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.english-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.dark-mild",
				Name = "Dark Mild",
				OriginalGravityMinimum = 3m,
				OriginalGravityMaximum = 3.8m,
				Description = "A dark, low-gravity, malt-focused British session ale readily suited to drinking in quantity. Refreshing, yet flavorful, with a wide range of dark malt or dark sugar expression.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.dark-mild", StyleTagCode = "bjcp-2015.brown-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.british-brown-ale",
				Name = "British Brown Ale",
				OriginalGravityMinimum = 4.2m,
				OriginalGravityMaximum = 5.4m,
				Description = "A malty, brown caramel-centric British ale without the roasted flavors of a Porter. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.british-brown-ale", StyleTagCode = "bjcp-2015.brown-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.english-porter",
				Name = "English Porter",
				OriginalGravityMinimum = 4m,
				OriginalGravityMaximum = 5.4m,
				Description = "A moderate-strength brown beer with a restrained roasty character and bitterness. May have a range of roasted flavors, generally without burnt qualities, and often has a chocolate-caramel-malty profile.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.english-porter", StyleTagCode = "bjcp-2015.porter-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.scottish-light",
				Name = "Scottish Light",
				OriginalGravityMinimum = 2.5m,
				OriginalGravityMaximum = 3.2m,
				Description = "A malt-focused, generally caramelly beer with perhaps a few esters and occasionally a butterscotch aftertaste. Hops only to balance and support the malt. The malt character can range from dry and grainy to rich, toasty, and caramelly, but is never roasty and especially never has a peat smoke character. Traditionally the darkest of the Scottish ales, sometimes nearly black but lacking any burnt, overtly roasted character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.scottish-light", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.scottish-heavy",
				Name = "Scottish Heavy",
				OriginalGravityMinimum = 3.2m,
				OriginalGravityMaximum = 3.9m,
				Description = "A malt-focused, generally caramelly beer with perhaps a few esters and occasionally a butterscotch aftertaste. Hops only to balance and support the malt. The malt character can range from dry and grainy to rich, toasty, and caramelly, but is never roasty and especially never has a peat smoke character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.scottish-heavy", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.scottish-export",
				Name = "Scottish Export",
				OriginalGravityMinimum = 3.9m,
				OriginalGravityMaximum = 6m,
				Description = "A malt-focused, generally caramelly beer with perhaps a few esters and occasionally a butterscotch aftertaste. Hops only to balance and support the malt. The malt character can range from dry and grainy to rich, toasty, and caramelly, but is never roasty and especially never has a peat smoke character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.scottish-export", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.irish-red-ale",
				Name = "Irish Red Ale",
				OriginalGravityMinimum = 3.8m,
				OriginalGravityMaximum = 5m,
				Description = "An easy-drinking pint, often with subtle flavors. Slightly malty in the balance sometimes with an initial soft toffee/caramel sweetness, a slightly grainy-biscuity palate, and a touch of roasted dryness in the finish. Some versions can emphasize the caramel and sweetness more, while others will favor the grainy palate and roasted dryness.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.irish-red-ale", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.irish-stout",
				Name = "Irish Stout",
				OriginalGravityMinimum = 4m,
				OriginalGravityMaximum = 4.5m,
				Description = "A black beer with a pronounced roasted flavor, often similar to coffee. The balance can range from fairly even to quite bitter, with the more balanced versions having a little malty sweetness and the bitter versions being quite dry. Draught versions typically are creamy from a nitro pour, but bottled versions will not have this dispense-derived character. The roasted flavor can be dry and coffee-like to somewhat chocolaty. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.irish-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.irish-extra-stout",
				Name = "Irish Extra Stout",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 6.5m,
				Description = "A fuller-bodied black beer with a pronounced roasted flavor, often similar to coffee and dark chocolate with some malty complexity. The balance can range from moderately bittersweet to bitter, with the more balanced versions having up to moderate malty richness and the bitter versions being quite dry.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.irish-extra-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.sweet-stout",
				Name = "Sweet Stout",
				OriginalGravityMinimum = 4m,
				OriginalGravityMaximum = 6m,
				Description = "A very dark, sweet, full-bodied, slightly roasty ale that can suggest coffee-and-cream, or sweetened espresso.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.sweet-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.oatmeal-stout",
				Name = "Oatmeal Stout",
				OriginalGravityMinimum = 4.2m,
				OriginalGravityMaximum = 5.9m,
				Description = "A very dark, full-bodied, roasty, malty ale with a complementary oatmeal flavor. The sweetness, balance, and oatmeal impression can vary considerably.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.oatmeal-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.tropical-stout",
				Name = "Tropical Stout",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 8m,
				Description = "A very dark, sweet, fruity, moderately strong ale with smooth roasty flavors without a burnt harshness.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.tropical-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.foreign-extra-stout",
				Name = "Foreign Extra Stout",
				OriginalGravityMinimum = 6.3m,
				OriginalGravityMaximum = 8m,
				Description = "A very dark, moderately strong, fairly dry, stout with prominent roast flavors.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.foreign-extra-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.british-strong-ale",
				Name = "British Strong Ale",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 8m,
				Description = "An ale of respectable alcoholic strength, traditionally bottled-conditioned and cellared. Can have a wide range of interpretations, but most will have varying degrees of malty richness, late hops and bitterness, fruity esters, and alcohol warmth. Judges should allow for a significant range in character, as long as the beer is within the alcohol strength range and has an interesting ‘British’ character, it likely fits the style. The malt and adjunct flavors and intensity can vary widely, but any combination should result in an agreeable palate experience.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.british-strong-ale", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.old-ale",
				Name = "Old Ale",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 9m,
				Description = "An ale of moderate to fairly significant alcoholic strength, bigger than standard beers, though usually not as strong or rich as barleywine. Often tilted towards a maltier balance. “It should be a warming beer of the type that is best drunk in half pints by a warm fire on a cold winter’s night” – Michael Jackson.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.old-ale", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.wee-heavy",
				Name = "Wee Heavy",
				OriginalGravityMinimum = 6.5m,
				OriginalGravityMaximum = 10m,
				Description = "Rich, malty, dextrinous, and usually caramel-sweet, these beers can give an impression that is suggestive of a dessert. Complex secondary malt and alcohol flavors prevent a one-dimensional quality. Strength and maltiness can vary, but should not be cloying or syrupy.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.wee-heavy", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.english-barleywine",
				Name = "English Barleywine",
				OriginalGravityMinimum = 8m,
				OriginalGravityMaximum = 12m,
				Description = "A showcase of malty richness and complex, intense flavors. Chewy and rich in body, with warming alcohol and a pleasant fruity or hoppy interest. When aged, it can take on port-like flavors. A wintertime sipper.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.english-barleywine", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.blonde-ale",
				Name = "Blonde Ale",
				OriginalGravityMinimum = 3.8m,
				OriginalGravityMaximum = 5.5m,
				Description = "Easy-drinking, approachable, malt-oriented American craft beer, often with interesting fruit, hop, or character malt notes. Well-balanced and clean, is a refreshing pint without aggressive flavors.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.blonde-ale", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-pale-ale",
				Name = "American Pale Ale",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 6.2m,
				Description = "A pale, refreshing and hoppy ale, yet with sufficient supporting malt to make the beer balanced and drinkable. The clean hop presence can reflect classic or modern American or New World hop varieties with a wide range of characteristics. An average-strength hop-forward pale American craft beer, generally balanced to be more accessible than modern American IPAs.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-pale-ale", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-amber-ale",
				Name = "American Amber Ale",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 6.2m,
				Description = "An amber, hoppy, moderate-strength American craft beer with a caramel malty flavor. The balance can vary quite a bit, with some versions being fairly malty and others being aggressively hoppy. Hoppy and bitter versions should not have clashing flavors with the caramel malt profile.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-amber-ale", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.california-common-",
				Name = "California Common ",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 5.5m,
				Description = "A lightly fruity beer with firm, grainy maltiness, interesting toasty and caramel flavors, and showcasing rustic, traditional American hop characteristics.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.california-common-", StyleTagCode = "bjcp-2015.amber-lager-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-brown-ale",
				Name = "American Brown Ale",
				OriginalGravityMinimum = 4.3m,
				OriginalGravityMaximum = 6.2m,
				Description = "A malty but hoppy beer frequently with chocolate and caramel flavors. The hop flavor and aroma complements and enhances the malt rather than clashing with it.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-brown-ale", StyleTagCode = "bjcp-2015.brown-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-porter",
				Name = "American Porter",
				OriginalGravityMinimum = 4.8m,
				OriginalGravityMaximum = 6.5m,
				Description = "A substantial, malty dark beer with a complex and flavorful dark malt character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-porter", StyleTagCode = "bjcp-2015.porter-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-stout",
				Name = "American Stout",
				OriginalGravityMinimum = 5m,
				OriginalGravityMaximum = 7m,
				Description = "A fairly strong, highly roasted, bitter, hoppy dark stout. Has the body and dark flavors typical of stouts with a more aggressive American hop character and bitterness.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.imperial-stout",
				Name = "Imperial Stout",
				OriginalGravityMinimum = 8m,
				OriginalGravityMaximum = 12m,
				Description = "An intensely-flavored, big, dark ale with a wide range of flavor balances and regional interpretations. Roasty-burnt malt with deep dark or dried fruit flavors, and a warming, bittersweet finish. Despite the intense flavors, the components need to meld together to create a complex, harmonious beer, not a hot mess.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.imperial-stout", StyleTagCode = "bjcp-2015.stout-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-ipa",
				Name = "American IPA",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 7.5m,
				Description = "A decidedly hoppy and bitter, moderately strong American pale ale, showcasing modern American or New World hop varieties. The balance is hop-forward, with a clean fermentation profile, dryish finish, and clean, supporting malt allowing a creative range of hop character to shine through.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-ipa---belgian-ipa",
				Name = "Specialty IPA - Belgian IPA",
				OriginalGravityMinimum = 6.2m,
				OriginalGravityMaximum = 9.5m,
				Description = "An IPA with the fruitiness and spiciness derived from the use of Belgian yeast. The examples from Belgium tend to be lighter in color and more attenuated, similar to a tripel that has been brewed with more hops. This beer has a more complex flavor profile and may be higher in alcohol than a typical IPA.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-ipa---belgian-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-ipa---black-ipa",
				Name = "Specialty IPA - Black IPA",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 9m,
				Description = "A beer with the dryness, hop-forward balance, and flavor characteristics of an American IPA, only darker in color – but without strongly roasted or burnt flavors. The flavor of darker malts is gentle and supportive, not a major flavor component. Drinkability is a key characteristic.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-ipa---black-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-ipa---brown-ipa",
				Name = "Specialty IPA - Brown IPA",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 7.5m,
				Description = "Hoppy, bitter, and moderately strong like an American IPA, but with some caramel, chocolate, toffee, and/or dark fruit malt character as in an American Brown Ale. Retaining the dryish finish and lean body that makes IPAs so drinkable, a Brown IPA is a little more flavorful and malty than an American IPA without being sweet or heavy.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-ipa---brown-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-ipa---red-ipa",
				Name = "Specialty IPA - Red IPA",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 7.5m,
				Description = "Hoppy, bitter, and moderately strong like an American IPA, but with some caramel, toffee, and/or dark fruit malt character. Retaining the dryish finish and lean body that makes IPAs so drinkable, a Red IPA is a little more flavorful and malty than an American IPA without being sweet or heavy.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-ipa---red-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-ipa---rye-ipa",
				Name = "Specialty IPA - Rye IPA",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 8m,
				Description = "A decidedly hoppy and bitter, moderately strong American pale ale, showcasing modern American and New World hop varieties and rye malt. The balance is hop-forward, with a clean fermentation profile, dry finish, and clean, supporting malt allowing a creative range of hop character to shine through.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-ipa---rye-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-ipa---white-ipa",
				Name = "Specialty IPA - White IPA",
				OriginalGravityMinimum = 5.5m,
				OriginalGravityMaximum = 7m,
				Description = "A fruity, spicy, refreshing version of an American IPA, but with a lighter color, less body, and featuring either the distinctive yeast and/or spice additions typical of a Belgian witbier.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-ipa---white-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.double-ipa",
				Name = "Double IPA",
				OriginalGravityMinimum = 7.5m,
				OriginalGravityMaximum = 10m,
				Description = "An intensely hoppy, fairly strong pale ale without the big, rich, complex maltiness and residual sweetness and body of an American barleywine. Strongly hopped, but clean, dry, and lacking harshness. Drinkability is an important characteristic; this should not be a heavy, sipping beer.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.double-ipa", StyleTagCode = "bjcp-2015.ipa-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-strong-ale",
				Name = "American Strong Ale",
				OriginalGravityMinimum = 6.3m,
				OriginalGravityMaximum = 10m,
				Description = "A strong, full-flavored American ale that challenges and rewards the palate with full malty and hoppy flavors and substantial bitterness. The flavors are bold but complementary, and are stronger and richer than average-strength pale and amber American ales.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-strong-ale", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.american-barleywine",
				Name = "American Barleywine",
				OriginalGravityMinimum = 8m,
				OriginalGravityMaximum = 12m,
				Description = "A well-hopped American interpretation of the richest and strongest of the English ales. The hop character should be evident throughout, but does not have to be unbalanced. The alcohol strength and hop bitterness often combine to leave a very long finish.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.american-barleywine", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.wheatwine",
				Name = "Wheatwine",
				OriginalGravityMinimum = 8m,
				OriginalGravityMaximum = 12m,
				Description = "A richly textured, high alcohol sipping beer with a significant grainy, bready flavor and sleek body. The emphasis is first on the bready, wheaty flavors with interesting complexity from malt, hops, fruity yeast character and alcohol complexity.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.wheatwine", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.berliner-weisse",
				Name = "Berliner Weisse",
				OriginalGravityMinimum = 2.8m,
				OriginalGravityMaximum = 3.8m,
				Description = "A very pale, refreshing, low-alcohol German wheat beer with a clean lactic sourness and a very high carbonation level. A light bread dough malt flavor supports the sourness, which shouldn’t seem artificial. Any Brettanomyces funk is restrained.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.berliner-weisse", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.flanders-red-ale",
				Name = "Flanders Red Ale",
				OriginalGravityMinimum = 4.6m,
				OriginalGravityMaximum = 6.5m,
				Description = "A sour, fruity, red wine-like Belgian-style ale with interesting supportive malt flavors and fruit complexity. The dry finish and tannin completes the mental image of a fine red wine.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.flanders-red-ale", StyleTagCode = "bjcp-2015.sour-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.oud-bruin",
				Name = "Oud Bruin",
				OriginalGravityMinimum = 4m,
				OriginalGravityMaximum = 8m,
				Description = "A malty, fruity, aged, somewhat sour Belgian-style brown ale.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.oud-bruin", StyleTagCode = "bjcp-2015.sour-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.lambic",
				Name = "Lambic",
				OriginalGravityMinimum = 5m,
				OriginalGravityMaximum = 6.5m,
				Description = "A fairly sour, often moderately funky wild Belgian wheat beer with sourness taking the place of hop bitterness in the balance. Traditionally spontaneously fermented in the Brussels area and served uncarbonated, the refreshing acidity makes for a very pleasant café drink. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.lambic", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.gueuze-",
				Name = "Gueuze ",
				OriginalGravityMinimum = 5m,
				OriginalGravityMaximum = 8m,
				Description = "A complex, pleasantly sour but balanced wild Belgian wheat beer that is highly carbonated and very refreshing. The spontaneous fermentation character can provide a very interesting complexity, with a wide range of wild barnyard, horse blanket, or leather characteristics intermingling with citrusy-fruity flavors and acidity.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.gueuze-", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.fruit-lambic",
				Name = "Fruit Lambic",
				OriginalGravityMinimum = 5m,
				OriginalGravityMaximum = 7m,
				Description = "A complex, fruity, pleasantly sour, wild wheat ale fermented by a variety of Belgian microbiota, and showcasing the fruit contributions blended with the wild character. The type of fruit can sometimes be hard to identify as fermented and aged fruit characteristics can seem different from the more recognizable fresh fruit aromas and flavors.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.fruit-lambic", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.witbier",
				Name = "Witbier",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 5.5m,
				Description = "A refreshing, elegant, tasty, moderate-strength wheat-based ale.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.witbier", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.belgian-pale-ale",
				Name = "Belgian Pale Ale",
				OriginalGravityMinimum = 4.8m,
				OriginalGravityMaximum = 5.5m,
				Description = "A moderately malty, somewhat fruity, easy-drinking, copper-colored Belgian ale that is somewhat less aggressive in flavor profile than many other Belgian beers. The malt character tends to be a bit biscuity with light toasty, honey-like, or caramelly components; the fruit character is noticeable and complementary to the malt. The bitterness level is generally moderate, but may not seem as high due to the flavorful malt profile.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.belgian-pale-ale", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.bière-de-garde",
				Name = "Bière de Garde",
				OriginalGravityMinimum = 6m,
				OriginalGravityMaximum = 8.5m,
				Description = "A fairly strong, malt-accentuated, lagered artisanal beer with a range of malt flavors appropriate for the color. All are malty yet dry, with clean flavors and a smooth character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.bière-de-garde", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.belgian-blond-ale",
				Name = "Belgian Blond Ale",
				OriginalGravityMinimum = 6m,
				OriginalGravityMaximum = 7.5m,
				Description = "A moderate-strength golden ale that has a subtle fruity-spicy Belgian yeast complexity, slightly malty-sweet flavor, and dry finish.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.belgian-blond-ale", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.saison",
				Name = "Saison",
				OriginalGravityMinimum = 3.5m,
				OriginalGravityMaximum = 9.5m,
				Description = "Most commonly, a pale, refreshing, highly-attenuated, moderately-bitter, moderate-strength Belgian ale with a very dry finish. Typically highly carbonated, and using non-barley cereal grains and optional spices for complexity, as complements the expressive yeast character that is fruity, spicy, and not overly phenolic. Less common variations include both lower-alcohol and higher-alcohol products, as well as darker versions with additional malt character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.saison", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.belgian-golden-strong-ale",
				Name = "Belgian Golden Strong Ale",
				OriginalGravityMinimum = 7.5m,
				OriginalGravityMaximum = 10.5m,
				Description = "A pale, complex, effervescent, strong Belgian-style ale that is highly attenuated and features fruity and hoppy notes in preference to phenolics.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.belgian-golden-strong-ale", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.trappist-single",
				Name = "Trappist Single",
				OriginalGravityMinimum = 4.8m,
				OriginalGravityMaximum = 6m,
				Description = "A pale, bitter, highly attenuated and well carbonated Trappist ale, showing a fruity-spicy Trappist yeast character, a spicy-floral hop profile, and a soft, supportive grainy-sweet malt palate. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.trappist-single", StyleTagCode = "bjcp-2015.pale-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.belgian-dubbel",
				Name = "Belgian Dubbel",
				OriginalGravityMinimum = 6m,
				OriginalGravityMaximum = 7.6m,
				Description = "A deep reddish-copper, moderately strong, malty, complex Trappist ale with rich malty flavors, dark or dried fruit esters, and light alcohol blended together in a malty presentation that still finishes fairly dry.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.belgian-dubbel", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.belgian-tripel",
				Name = "Belgian Tripel",
				OriginalGravityMinimum = 7.5m,
				OriginalGravityMaximum = 9.5m,
				Description = "A pale, somewhat spicy, dry, strong Trappist ale with a pleasant rounded malt flavor and firm bitterness. Quite aromatic, with spicy, fruity, and light alcohol notes combining with the supportive clean malt character to produce a surprisingly drinkable beverage considering the high alcohol level.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.belgian-tripel", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.belgian-dark-strong-ale",
				Name = "Belgian Dark Strong Ale",
				OriginalGravityMinimum = 8m,
				OriginalGravityMaximum = 12m,
				Description = "A dark, complex, very strong Belgian ale with a delicious blend of malt richness, dark fruit flavors, and spicy elements. Complex, rich, smooth and dangerous.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.belgian-dark-strong-ale", StyleTagCode = "bjcp-2015.strong-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.gose",
				Name = "Gose",
				OriginalGravityMinimum = 4.2m,
				OriginalGravityMaximum = 4.8m,
				Description = "A highly-carbonated, tart and fruity wheat ale with a restrained coriander and salt character and low bitterness. Very refreshing, with bright flavors and high attenuation.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.gose", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.kentucky-common",
				Name = "Kentucky Common",
				OriginalGravityMinimum = 4m,
				OriginalGravityMaximum = 5.5m,
				Description = "A darker-colored, light-flavored, malt-accented beer with a dry finish and interesting character malt flavors. Refreshing due to its high carbonation and mild flavors, and highly sessionable due to being served very fresh and with restrained alcohol levels.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.kentucky-common", StyleTagCode = "bjcp-2015.amber-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.lichtenhainer",
				Name = "Lichtenhainer",
				OriginalGravityMinimum = 3.5m,
				OriginalGravityMaximum = 4.7m,
				Description = "A sour, smoked, lower-gravity historical German wheat beer. Complex yet refreshing character due to high attenuation and carbonation, along with low bitterness and moderate sourness. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.lichtenhainer", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.london-brown-ale",
				Name = "London Brown Ale",
				OriginalGravityMinimum = 2.8m,
				OriginalGravityMaximum = 3.6m,
				Description = "A luscious, sweet, malt-oriented dark brown ale, with caramel and toffee malt complexity and a sweet finish.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.london-brown-ale", StyleTagCode = "bjcp-2015.brown-ale-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.piwo-grodziskie",
				Name = "Piwo Grodziskie",
				OriginalGravityMinimum = 2.5m,
				OriginalGravityMaximum = 3.3m,
				Description = "A low-gravity, highly-carbonated, light-bodied ale combining an oak-smoked flavor with a clean hop bitterness. Highly sessionable.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.piwo-grodziskie", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.pre-prohibition-lager",
				Name = "Pre-Prohibition Lager",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 6m,
				Description = "A clean, refreshing, but bitter pale lager, often showcasing a grainy-sweet corn flavor. All malt or rice-based versions have a crisper, more neutral character. The higher bitterness level is the largest differentiator between this style and most modern mass-market pale lagers, but the more robust flavor profile also sets it apart.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.pre-prohibition-lager", StyleTagCode = "bjcp-2015.pilsner-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.pre-prohibition-porter",
				Name = "Pre-Prohibition Porter",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 6m,
				Description = "An American adaptation of English Porter using American ingredients, including adjuncts.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.pre-prohibition-porter", StyleTagCode = "bjcp-2015.porter-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.roggenbier",
				Name = "Roggenbier",
				OriginalGravityMinimum = 4.5m,
				OriginalGravityMaximum = 6m,
				Description = "A dunkelweizen made with rye rather than wheat, but with a greater body and light finishing hops.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.roggenbier", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.sahti",
				Name = "Sahti",
				OriginalGravityMinimum = 7m,
				OriginalGravityMaximum = 11m,
				Description = "A sweet, heavy, strong traditional Finnish beer with a rye, juniper, and juniper berry flavor and a strong banana-clove yeast character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.sahti", StyleTagCode = "bjcp-2015.wheat-beer-family"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.brett-beer",
				Name = "Brett Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "Most often drier and fruitier than the base style suggests. Funky notes range from low to high, depending on the age of the beer and strain(s) of Brett used. Funkiness is generally restrained in younger 100% Brett examples, but tends to increase with age. May possess a light acidity, although this does not come from Brett.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.brett-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.mixed-fermentation-sour-beer",
				Name = "Mixed-Fermentation Sour Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A sour and/or funky version of a base style of beer.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.mixed-fermentation-sour-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.wild-specialty-beer",
				Name = "Wild Specialty Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A sour and/or funky version of a fruit, herb, or spice beer, or a wild beer aged in wood. If wood-aged, the wood should not be the primary or dominant character.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.wild-specialty-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.fruit-beer",
				Name = "Fruit Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A harmonious marriage of fruit and beer, but still recognizable as a beer. The fruit character should be evident but in balance with the beer, not so forward as to suggest an artificial product.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.fruit-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.fruit-and-spice-beer",
				Name = "Fruit and Spice Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A harmonious marriage of fruit, spice, and beer, but still recognizable as a beer. The fruit and spice character should each be evident but in balance with the beer, not so forward as to suggest an artificial product.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.fruit-and-spice-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-fruit-beer",
				Name = "Specialty Fruit Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A harmonious marriage of fruit, sugar, and beer, but still recognizable as a beer. The fruit and sugar character should both be evident but in balance with the beer, not so forward as to suggest an artificial product.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-fruit-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.spice,-herb,-or-vegetable-beer",
				Name = "Spice, Herb, or Vegetable Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A harmonious marriage of SHV and beer, but still recognizable as a beer. The SHV character should be evident but in balance with the beer, not so forward as to suggest an artificial product. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.spice,-herb,-or-vegetable-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.autumn-seasonal-beer",
				Name = "Autumn Seasonal Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "An amber to copper, spiced beer that often has a moderately rich body and slightly warming finish suggesting a good accompaniment for the cool fall season, and often evocative of Thanksgiving traditions.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.autumn-seasonal-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.winter-seasonal-beer",
				Name = "Winter Seasonal Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A stronger, darker, spiced beer that often has a rich body and warming finish suggesting a good accompaniment for the cold winter season.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.winter-seasonal-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.alternative-grain-beer",
				Name = "Alternative Grain Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A base beer enhanced by or featuring the character of additional grain or grains. The specific character depends greatly on the character of the added grains.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.alternative-grain-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.alternative-sugar-beer",
				Name = "Alternative Sugar Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A harmonious marriage of sugar and beer, but still recognizable as a beer. The sugar character should both be evident but in balance with the beer, not so forward as to suggest an artificial product.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.alternative-sugar-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.classic-style-smoked-beer",
				Name = "Classic Style Smoked Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A smoke-enhanced beer showing good balance between the smoke and beer character, while remaining pleasant to drink. Balance in the use of smoke, hops and malt character is exhibited by the better examples.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.classic-style-smoked-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-smoked-beer",
				Name = "Specialty Smoked Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A smoke-enhanced beer showing good balance between the smoke, the beer character, and the added ingredients, while remaining pleasant to drink. Balance in the use of smoke, hops and malt character is exhibited by the better examples.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-smoked-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.wood-aged-beer",
				Name = "Wood-Aged Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A harmonious blend of the base beer style with characteristics from aging in contact with wood. The best examples will be smooth, flavorful, well-balanced and well-aged. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.wood-aged-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.specialty-wood-aged-beer",
				Name = "Specialty Wood-Aged Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "A harmonious blend of the base beer style with characteristics from aging in contact with wood (including alcoholic products previously in contact with the wood). The best examples will be smooth, flavorful, well-balanced and well-aged. ",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.specialty-wood-aged-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.clone-beer",
				Name = "Clone Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "Based on declared clone beer.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.clone-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.mixed-style-beer",
				Name = "Mixed-Style Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "Based on the declared base styles. As with all Specialty-Type Beers, the resulting combination of beer styles needs to be harmonious and balanced, and be pleasant to drink.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.mixed-style-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

			context.Styles.Add(new Style
			{
				Code = "bjcp-2015.experimental-beer",
				Name = "Experimental Beer",
				OriginalGravityMinimum = null,
				OriginalGravityMaximum = null,
				Description = "Varies, but should be a unique experience.",
				StyleTags = new List<StyleTagAssociation> { new StyleTagAssociation { StyleCode = "bjcp-2015.experimental-beer", StyleTagCode = "bjcp-2015.specialty-beer"}}
			});

            context.SaveChanges();
        }

        internal static bool SeedDataExists(ApplicationDbContext context)
        {
            return context.Users.Any();
        }
    }
}
