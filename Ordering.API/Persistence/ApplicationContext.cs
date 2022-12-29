using Microsoft.EntityFrameworkCore;
using Sale.API.Entities;
using System.Linq;

namespace Sale.API.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        //public DbSet<Sale> Sales { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            if (Buyers.ToList().Count == 0)
            {
                InitializeProductDefault();
            }
        }

        private void InitializeProductDefault()
        {
            Buyers.AddRange(
                new Buyer()
                {
                    Name = "Tom",
                },
                new Buyer()
                {
                    Name = "Bill",
                },
                new Buyer()
                {
                    Name = "John",
                }
            );

            this.SaveChanges();
        }
    }
}
