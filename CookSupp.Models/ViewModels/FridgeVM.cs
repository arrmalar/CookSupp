using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSupp.Models.ViewModels
{
    public class FridgeVM
    {
        public Fridge Fridge { get; set; }

        public ICollection<string> FridgeProductsNames { get; set; }
    }
}
