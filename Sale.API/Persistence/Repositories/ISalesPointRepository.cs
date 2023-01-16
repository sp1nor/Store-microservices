using Sale.API.Entities;
using System.Collections.Generic;

namespace Sale.API.Persistence.Repositories
{
    public interface ISalesPointRepository
    {
        IEnumerable<SalesPoint> GetAll();
        SalesPoint GetItemById(int id);
        void Create(SalesPoint item);

        void Update(SalesPoint item);
        void Delete(int id);
        void Delete(SalesPoint item);
        void Save();
    }
}
