using System.ComponentModel.DataAnnotations;

namespace Mission06_Pobanz.Models
{
    public class Categories
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
