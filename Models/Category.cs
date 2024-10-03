using System.ComponentModel.DataAnnotations;

namespace baby_shop_backend.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string CategoriesName { get; set; }

        public ICollection<Products> products { get; set; }

        

    }
}
