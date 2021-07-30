using lesson5.Domain.Entities;
using lesson5.lesson7.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    public class ProductAddModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class CatalogServiec
    {
        private readonly ICategoryRepository _categoryRepository;

        public CatalogServiec(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddProduct(ProductAddModel model)
        {
            var category = _categoryRepository
                .Get(x => x.Name == model.Category)
                .FirstOrDefault();
            if (category == null)
            {
                category = new Category();
                category.Name = model.Category;
                _categoryRepository.Add(category);
            }

        }
    }
}
