using BulkyBook.Model.Models;

namespace BulkyBook.DataAccess.IRepository
{
    public interface IOrderHeaderRepository : IBaseRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
    }
}
