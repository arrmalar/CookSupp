using CookSupp.DataAccess.Data;
using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;

namespace CookSupp.DataAccess.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private ApplicationDbContext _db;

        public RecipeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Recipe obj)
        {
            _db.Recipes.Update(obj);
        }
    }
}
