using System.Collections.Generic;

namespace BrewFree.Data.Models.Lookups
{
    public class Style : LookupBase
    {
        public decimal? OriginalGravityMinimum { get; set; }

        public decimal? OriginalGravityMaximum { get; set; }

        public decimal? FinalGravityMinimum { get; set; }

        public decimal? FinalGravityMaximum { get; set; }

        public decimal? ColorMinimum { get; set; }

        public decimal? ColorMaximum { get; set; }

        public decimal? AlcoholByVolumeMinimum { get; set; }

        public decimal? AlcoholByVolumeMaximum { get; set; }

        public virtual IList<StyleTagAssociation> StyleTags { get; set; } = new List<StyleTagAssociation>();

        public string Examples { get; set; }
    }
}
