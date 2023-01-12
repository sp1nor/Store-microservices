using Sale.API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sale.API.Persistence.Repositories
{
    public class SalesPointRepository : ISalesPointRepository
    {
        private readonly ApplicationContext _context;

        public SalesPointRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(SalesPoint item)
        {
            _context.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var salesPoint = _context.SalesPoints.FirstOrDefault(s => s.Id == id);

            _context.SalesPoints.Remove(salesPoint);
            Save();
        }

        public void Delete(SalesPoint item)
        {
            _context.SalesPoints.Remove(item);
            Save();
        }

        public IEnumerable<SalesPoint> GetAll()
        {
            return _context.SalesPoints.ToList();
        }

        public SalesPoint GetItemById(int id)
        {
            var salesPoint = _context.SalesPoints.FirstOrDefault(s => s.Id == id);

            return salesPoint;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(SalesPoint item)
        {
            var salesPoint = _context.SalesPoints.FirstOrDefault(s => s.Id == item.Id);
            salesPoint.Name = item.Name;
            salesPoint.ProvidedProducts = item.ProvidedProducts;
            Save();
        }
    }
}
