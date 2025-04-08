using System.ComponentModel.DataAnnotations;

namespace MvcTeste.Models
{
    public class Category
    {
        //data anotation
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }
}
