using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models.ViewModels
{
    public class FridgeVM
    {
        public Fridge Fridge { get; set; }

        public ICollection<int> SelectedProductsIds { get; set; }
    }
}
