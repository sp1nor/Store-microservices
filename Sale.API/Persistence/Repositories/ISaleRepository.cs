using System.Collections.Generic;

namespace Sale.API.Persistence.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Shared.Models.Sale> GetAll();
        Shared.Models.Sale GetItemById(int id);
        void Create(Shared.Models.Sale item);

        void Delete(int id);
        void Delete(Shared.Models.Sale item);
        void Save();
    }
}
