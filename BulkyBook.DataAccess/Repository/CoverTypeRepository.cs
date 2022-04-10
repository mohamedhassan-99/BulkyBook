using BulkyBook.DataAccess.IRepository;
using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : BaseRepository<CoverType>, ICoverTypeRepository
    {
        private readonly AppDbContext _context;

        public CoverTypeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        void ICoverTypeRepository.Update(CoverType coverType)
        {
            _context.Update(coverType);
        }
    }
}
