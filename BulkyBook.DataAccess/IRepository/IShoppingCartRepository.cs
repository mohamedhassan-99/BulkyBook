using BulkyBook.Model.ViewModels;

namespace BulkyBook.DataAccess.IRepository
{
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart);
    }
}
