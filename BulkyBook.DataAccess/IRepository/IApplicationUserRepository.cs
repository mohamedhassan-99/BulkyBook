using BulkyBook.Model.Models;

namespace BulkyBook.DataAccess.IRepository
{
    public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
    {
        void Update(ApplicationUser applicationUser);
    }
}
