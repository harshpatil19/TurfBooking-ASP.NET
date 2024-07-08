using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurfBookingSystem.Models
{
    public class Turf
    {
        [Key]
        public int TurfId { get; set; }
        [Column("Games",TypeName ="varchar(50)")]
        [Required]
        public string GameName { get; set; }
        [Column("Location", TypeName = "varchar(50)")]
        [Required]
        public string Location { get; set; }
        [Required]
        public int? Capacity { get; set; }
        [Required]  
        public double Price { get; set; }
    }
}
