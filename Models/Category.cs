using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcTeste.Models
{
    public class Category
    {
        //data anotation
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be beetwen 1-100")]
        public int DisplayOrder { get; set; }
    }
}
