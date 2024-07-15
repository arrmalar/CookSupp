using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models
{
    public class RecipeProduct
    {
        [Key, Column(Order = 0)]
        public int RecipeId { get; set; }

        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        public string? Unit { get; set; }

        public double? Quantity { get; set; }

        public Recipe Recipe { get; set; }

        public Product Product { get; set; }
    }
}
