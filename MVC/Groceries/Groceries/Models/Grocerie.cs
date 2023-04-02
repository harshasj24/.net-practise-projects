using System.ComponentModel.DataAnnotations;

namespace Groceries.Models
{
    public class Grocerie
    {
        [Key]
        public int id { get; set; }
        [Required] 
        public string imgUrl { get; set; } 
        [Required]
        public string grocerie_name { get; set; }
        [Required]
        public string grocerie_price { get; set; }
        [Required]
        public string groceries_decription { get; set; }

    }
}
