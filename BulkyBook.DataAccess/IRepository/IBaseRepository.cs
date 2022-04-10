using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll(string? includes = null);
        T GetFirstOrDefualt(Expression<Func<T,bool>> filter, string? includes = null);
        T Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
