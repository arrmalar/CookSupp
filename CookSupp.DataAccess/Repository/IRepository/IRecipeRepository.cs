using CookSupp.Models;

namespace CookSupp.DataAccess.Repository.IRepository
{
    public interface IRecipeRepository: IRepository<Recipe>
    {
        void Update(Recipe obj);
    }
}
