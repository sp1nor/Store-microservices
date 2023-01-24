using System.Collections.Generic;
using System.Linq;

namespace Sale.API.Persistence.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationContext _context;

        public SaleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Shared.Models.Sale item)
        {
            _context.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.Id == id);

            _context.Sales.Remove(sale);
            Save();
        }

        public void Delete(Shared.Models.Sale item)
        {
            _context.Sales.Remove(item);
            Save();
        }

        public IEnumerable<Shared.Models.Sale> GetAll()
        {
            return _context.Sales.ToList();
        }

        public Shared.Models.Sale GetItemById(int id)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.Id == id);

            return sale;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
