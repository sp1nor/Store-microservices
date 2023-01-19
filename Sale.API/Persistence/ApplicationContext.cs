using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Sale.API.Entities;

namespace Sale.API.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SalesPoint> SalesPoints { get; set; }

        public DbSet<Shared.Models.Sale> Sales { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            if (SalesPoints.ToList().Count == 0)
            {
                InitializeProductDefault();
            }
        }

        private void InitializeProductDefault()
        {
            SalesPoints.AddRange(
                new SalesPoint()
                {
                    Name = "store1",
                    ProvidedProducts = new List<ProvidedProduct>()
                    {
                        new ProvidedProduct()
                        {
                            ProductId = 1,
                            ProductQuantity = 4
                        },
                        new ProvidedProduct()
                        {
                            ProductId = 2,
                            ProductQuantity = 14
                        }
                    }
                },
                new SalesPoint()
                {
                    Name = "store2",
                    ProvidedProducts = new List<ProvidedProduct>()
                    {
                        new ProvidedProduct()
                        {
                            ProductId = 3,
                            ProductQuantity = 9
                        },
                        new ProvidedProduct()
                        {
                            ProductId = 4,
                            ProductQuantity = 7
                        }
                    }
                }
            );

            this.SaveChanges();
        }
    }
}
