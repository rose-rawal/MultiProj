using System.ComponentModel.DataAnnotations;

namespace MultiProj.Models
{
    public class Category
    {
        [Key]
        public   int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
