using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.IRepository
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        void Update(Company company);
    }
}
