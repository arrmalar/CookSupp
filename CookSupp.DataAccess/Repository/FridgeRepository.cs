using CookSupp.DataAccess.Data;
using CookSupp.DataAccess.Repository.IRepository;
using CookSupp.Models;

namespace CookSupp.DataAccess.Repository
{
    internal class FridgeRepository : Repository<Fridge>, IFridgeRepository
    {
        private ApplicationDbContext _db;

        public FridgeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Fridge obj)
        {
            _db.Fridges.Update(obj);
        }
    }
}
