using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<FridgeProduct> FridgeProducts { get; set; }
        public ICollection<RecipeProduct> RecipeProducts { get; set; }

    }
}
