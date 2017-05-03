using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrewFree.Data.Constants;
using BrewFree.Data.Models.Lookups;

namespace BrewFree.Data.Models
{
    public class Recipe
    {
        [Key]
        [MaxLength(MaxLengthType.Key)]
        public string Id { get; set; }

        [ForeignKey("Brewer")]
        public string BrewerId { get; set; }

        public virtual Brewer Brewer { get; set; }

        [ForeignKey("BrewingMethod")]
        public string BrewingMethodCode { get; set; }
        
        public virtual BrewingMethod BrewingMethod { get; set; }

        [MaxLength(MaxLengthType.Medium)]
        public string Name { get; set; }

        [MaxLength(MaxLengthType.Long)]
        public string Description { get; set; }

        [ForeignKey("Style")]
        public string StyleCode { get; set; }

        public virtual Style Style { get; set; }
    }
}
