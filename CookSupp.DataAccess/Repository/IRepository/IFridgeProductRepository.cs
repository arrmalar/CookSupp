using CookSupp.Models;

namespace CookSupp.DataAccess.Repository.IRepository
{
    public interface IFridgeProductRepository : IRepository<FridgeProduct>
    {
        void Update(FridgeProduct obj);
    }
}
