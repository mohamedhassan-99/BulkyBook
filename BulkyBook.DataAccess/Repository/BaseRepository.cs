using BulkyBook.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;
        public BaseRepository(AppDbContext context)
        {
            this._context = context;

            this.dbSet = _context.Set<T>();
        } 
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includes = null)
        {
            IQueryable<T> query = dbSet;
            if(includes != null)
            {
                foreach(var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }
            
            return query.ToList();
        }

        public T GetFirstOrDefualt(Expression<Func<T, bool>> filter, string? includes = null)
        {
            IQueryable<T> query = dbSet;
            
            query = query.Where(filter);

            if (includes != null)
            {
                foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
