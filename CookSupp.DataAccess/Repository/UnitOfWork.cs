using CookSupp.DataAccess.Data;
using CookSupp.DataAccess.Repository.IRepository;

namespace CookSupp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IProductRepository ProductRepository { get; private set; }

        public IRecipeRepository RecipeRepository { get; private set; }

        public IFridgeRepository FridgeRepository { get; private set; }

        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public IFridgeProductRepository FridgeProductRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ProductRepository = new ProductRepository(_db);
            RecipeRepository = new RecipeRepository(_db);
            FridgeRepository = new FridgeRepository(_db);
            FridgeProductRepository = new FridgeProductRepository(_db);
            ApplicationUserRepository = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
