using CatalogService.API.Persistence;

namespace Catalog.API.Persistence
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        private IProductRepository _products;

        public EFUnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_context);
                }

                return _products;
            }
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
