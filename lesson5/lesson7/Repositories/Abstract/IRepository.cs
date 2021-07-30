using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5.lesson7.Repositories.Abstract
{
    public interface IRepository<X, Y> where X : class
    {
        void Add(X item);

        X FindById(Y id);

        IQueryable<X> Get(Func<X, bool> predicate);
    }
}
