using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models.ViewModels
{
    public class SearchDataVM
    {
        [ValidateNever]
        public string? Text { get; set; }
        [ValidateNever]
        public ICollection<int> SelectedProductsIds { get; set; }
        [ValidateNever]
        public ICollection<Recipe> SearchedRecipes { get; set; }
    }
}
