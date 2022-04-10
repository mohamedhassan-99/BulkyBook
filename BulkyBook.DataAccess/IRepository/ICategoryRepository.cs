using BulkyBook.Model.Models;

namespace BulkyBook.DataAccess.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        void Update(Category category);
    }
}
