using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookSupp.Models
{
    public class RecipeStep
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        [ValidateNever]
        public Recipe Recipe { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public int Description { get; set; }

        [Required]
        public ICollection<RecipeProduct> RecipeProducts { get; set; }
    }
}
