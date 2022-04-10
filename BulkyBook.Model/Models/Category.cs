using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Model.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Display Order"),Range(0,100,ErrorMessage ="Must be between 0 and 100 only")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
