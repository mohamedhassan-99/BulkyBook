using BulkyBook.Model.Models;

namespace BulkyBook.DataAccess.IRepository
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        void Update(OrderDetail orderDetail);
    }
}
