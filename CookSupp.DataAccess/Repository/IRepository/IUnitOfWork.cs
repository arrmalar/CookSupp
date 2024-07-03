namespace CookSupp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IRecipeRepository RecipeRepository { get; }
        IFridgeRepository FridgeRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IFridgeProductRepository FridgeProductRepository { get; }
        void Save();
    }
}
