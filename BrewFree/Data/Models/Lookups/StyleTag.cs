using System.ComponentModel.DataAnnotations;
using BrewFree.Data.Constants;

namespace BrewFree.Data.Models.Lookups
{
    public class StyleTag : LookupBase
    {
        [Required]
        [MaxLength(MaxLengthType.Small)]
        public string TypeCode { get; set; }
    }
}
