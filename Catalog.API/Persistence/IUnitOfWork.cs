using CatalogService.API.Persistence;

namespace Catalog.API.Persistence
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        void Save();
    }
}
