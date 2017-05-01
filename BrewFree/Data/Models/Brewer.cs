using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrewFree.Data.Constants;

namespace BrewFree.Data.Models
{
    public class Brewer
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [MaxLength(MaxLengthType.Medium)]
        public string Name { get; set; }
    }
}
