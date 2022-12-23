using System.Collections.Generic;

namespace Ordering.API.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
