using lesson5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5.lesson7.Repositories.Abstract
{
    public interface ICategoryRepository : IRepository<Category, long>
    {
        void GetTreeCategory();
    }
}
