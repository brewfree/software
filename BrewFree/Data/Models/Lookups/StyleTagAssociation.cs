using System.ComponentModel.DataAnnotations.Schema;

namespace BrewFree.Data.Models.Lookups
{
    public class StyleTagAssociation
    {
        [ForeignKey(nameof(Style))]
        public string StyleCode { get; set; }

        public virtual Style Style { get; set; }

        [ForeignKey(nameof(StyleTag))]
        public string StyleTagCode { get; set; }

        public virtual StyleTag StyleTag { get; set; }
    }
}
