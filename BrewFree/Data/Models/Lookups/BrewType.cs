using System.ComponentModel.DataAnnotations;
using BrewFree.Data.Constants;

namespace BrewFree.Data.Models.Lookups
{
    public class BrewType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(MaxLengthType.Medium)]
        public string Name { get; set; }

        [MaxLength(MaxLengthType.Long)]
        public string Description { get; set; }
    }
}
