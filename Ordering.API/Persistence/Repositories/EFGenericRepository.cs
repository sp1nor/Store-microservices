using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sale.API.Persistence.Repositories
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        ApplicationContext _context;
        public DbSet<T> _dbSet;

        public EFGenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbSet.FirstOrDefault(x => x.Id == id);
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            var item = _dbSet.FirstOrDefault(x => x.Id == id);
            return item;
        }
    }
}
