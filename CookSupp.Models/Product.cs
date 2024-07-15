using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ValidateNever]
        public ICollection<FridgeProduct> FridgeProducts { get; set; }

        [ValidateNever]
        public ICollection<RecipeProduct> RecipeProducts { get; set; }
    }
}
