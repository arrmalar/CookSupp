using CookSupp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookSupp.DataAccess.Repository.IRepository
{
    public interface IRecipeRepository: IRepository<Recipe>
    {
        void Update(Recipe obj);
    }
}
