using CookSupp.DataAccess.Data;
using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;

namespace CookSupp.DataAccess.Repository
{
    public class FridgeProductRepository : Repository<FridgeProduct>, IFridgeProductRepository
    {
        private ApplicationDbContext _db;

        public FridgeProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FridgeProduct obj)
        {
            _db.FridgeProducts.Update(obj);
        }
    }
}
