
namespace CookSupp.Models.ViewModels
{
    public class RecipeVM
    {
        public Recipe Recipe { get; set; }
        public ICollection<int> SelectedProductsIds { get; set; }
    }
}
