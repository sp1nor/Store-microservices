using System.Collections.Generic;

namespace Ordering.API.Persistence.Repositories
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : class
    {
        ApplicationContext _context;

        public EFGenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
