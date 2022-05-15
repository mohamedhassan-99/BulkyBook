using BulkyBook.DataAccess.IRepository;
using BulkyBook.Model.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly AppDbContext _context;

        public ApplicationUserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        void IApplicationUserRepository.Update(ApplicationUser applicationUser)
        {
            _context.ApplicationUsers.Update(applicationUser);
        }
    }
}
