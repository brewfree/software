using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrewFree.Data.Constants;

namespace BrewFree.Data.Models
{
    public class Brewer
    {
        [Key]
        [MaxLength(MaxLengthType.Key)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [MaxLength(MaxLengthType.Medium)]
        public string Name { get; set; }

        public bool Shared { get; set; }
    }
}
