using lesson5.Domain.Entities;
using lesson5.lesson7.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5.lesson7.Repositories.Concrate
{
    public class CategoryRepository : Repository<Category, long>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }

        public void GetTreeCategory()
        {
            throw new NotImplementedException();
        }
    }
}
