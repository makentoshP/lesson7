using lesson5.lesson7.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5.lesson7.Repositories.Concrate
{
    public class Repository<T, Y> : IRepository<T, Y> where T : class
    {
        DbContext _context;
        DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public T FindById(Y id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }
    }
}
