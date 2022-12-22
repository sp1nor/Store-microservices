using CatalogService.API.Entities;
using System.Collections.Generic;

namespace CatalogService.API.Persistence
{
    public interface ICatalogRepository
    {
        IEnumerable<Product> GetAll();
        Product GetItemById(int id);
        void Create(Product item);

        void Update(Product item);
        void Delete(int id);
        void Delete(Product item);
    }
}
