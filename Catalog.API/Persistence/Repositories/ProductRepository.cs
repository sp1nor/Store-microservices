using CatalogService.API.Entities;
using CatalogService.API.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.API.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Product item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetItemById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            throw new System.NotImplementedException();
        }
    }
}
