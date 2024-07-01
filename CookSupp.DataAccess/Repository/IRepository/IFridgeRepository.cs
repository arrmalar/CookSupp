using CookSupp.Models;

namespace CookSupp.DataAccess.Repository.IRepository
{
    public interface IFridgeRepository : IRepository<Fridge>
    {
        void Update(Fridge obj);
    }
}
