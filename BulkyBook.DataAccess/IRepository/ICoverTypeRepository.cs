using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.IRepository
{
    public interface ICoverTypeRepository : IBaseRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}
