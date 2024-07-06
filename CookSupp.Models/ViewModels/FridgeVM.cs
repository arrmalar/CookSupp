using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models.ViewModels
{
    public class FridgeVM
    {
        public Fridge Fridge { get; set; }

        public List<int> SelectedProductsIds { get; set; }
    }
}
