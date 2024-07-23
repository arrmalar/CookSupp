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

        public void Update(Fridge fridge)
        {
            var objFromDb = _db.Fridges.FirstOrDefault(f => f.Id == fridge.Id);
            if (objFromDb != null)
            {
                objFromDb.ApplicationUserId = fridge.ApplicationUserId;
                objFromDb.Name = fridge.Name;
                _db.Entry(objFromDb).Collection(f => f.FridgeProducts).Load();
                objFromDb.FridgeProducts = fridge.FridgeProducts;
                _db.Fridges.Update(objFromDb);
            }
        }
    }
}
