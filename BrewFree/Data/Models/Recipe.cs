using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrewFree.Data.Constants;
using BrewFree.Data.Models.Lookups;

namespace BrewFree.Data.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Brewer")]
        public Guid BrewerId { get; set; }

        public virtual Brewer Brewer { get; set; }

        [ForeignKey("BrewType")]
        public int BrewTypeId { get; set; }
        
        public virtual BrewType BrewType { get; set; }

        [MaxLength(MaxLengthType.Medium)]
        public string Name { get; set; }

        [MaxLength(MaxLengthType.Long)]
        public string Description { get; set; }
    }
}
