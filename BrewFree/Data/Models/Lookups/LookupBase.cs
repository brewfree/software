using System.ComponentModel.DataAnnotations;
using BrewFree.Data.Constants;

namespace BrewFree.Data.Models.Lookups
{
    public abstract class LookupBase
    {
        [Key]
        [MaxLength(MaxLengthType.Medium)]
        public string Code { get; set; }

        [Required]
        [MaxLength(MaxLengthType.Medium)]
        public string Name { get; set; }

        [MaxLength(MaxLengthType.ExtraLong)]
        public string Description { get; set; }
    }
}
