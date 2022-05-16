using BulkyBook.Model.Models;

namespace BulkyBook.DataAccess.IRepository
{
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
    {
        int IncrementCount(ShoppingCart shoppingCart, int count);
        int DecrementCount(ShoppingCart shoppingCart, int count);

    }
}
