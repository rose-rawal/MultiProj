using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public   int CategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
