using CookSupp.DataAccess.Data;
using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;
using CookSupp.Models.ViewModels;

namespace CookSupp.DataAccess.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private ApplicationDbContext _db;

        public RecipeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Recipe recipe)
        {
            var objFromDb = _db.Recipes.FirstOrDefault(f => f.Id == recipe.Id);

            if (objFromDb != null)
            {
                objFromDb.Approved = recipe.Approved;
                objFromDb.ApplicationUserId = recipe.ApplicationUserId;
                objFromDb.Description = recipe.Description;
                objFromDb.Title = recipe.Title;

                _db.Entry(objFromDb).Collection(f => f.RecipeProducts).Load();
                objFromDb.RecipeProducts = recipe.RecipeProducts;
                _db.Recipes.Update(objFromDb);
            }
        }
    }
}
