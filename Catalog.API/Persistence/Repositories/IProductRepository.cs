using CatalogService.API.Entities;
using System.Collections.Generic;

namespace CatalogService.API.Persistence
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetItemById(int id);
        void Create(Product item);

        void Update(Product item);
        void Delete(int id);
        void Delete(Product item);
        void Save();
    }
}
