using System.Collections.Generic;

namespace Sale.API.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
