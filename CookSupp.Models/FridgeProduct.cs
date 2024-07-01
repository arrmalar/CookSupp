using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookSupp.Models
{
    public class FridgeProduct
    {
        [Key, Column(Order = 0)]
        public int FridgeId { get; set; }

        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        public Fridge Fridge { get; set; }
        public Product Product { get; set; }
    }
}
