using Catalog.API.Persistence;
using CatalogService.API.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ordering.UnitTests
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void Should_return_Correct_Price()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uof => uof.Products.GetAll()).Returns(GetTestProducts());
            var mockObject = mock.Object;
            // Act
            var result = mockObject.Products.GetAll();
            // Assert
            Assert.Equal(result.FirstOrDefault().Price, new Product() {Id = 1, Name = "firstProd", Price = 12332.02M }.Price);
        }

        [Fact]
        public void Should_return_Decimal_Price()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uof => uof.Products.GetAll()).Returns(GetTestProducts());
            var mockObject = mock.Object;
            // Act
            var result = mockObject.Products.GetAll();
            // Assert
            Assert.Equal(result.FirstOrDefault().Price.GetType(), new Product() { Id = 1, Name = "firstProd", Price = 12332.02M }.Price.GetType());
        }

        private List<Product> GetTestProducts()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "firstProd", Price = 12332.02M},
                new Product { Id = 2, Name = "secondProd", Price = 122.02M},
                new Product { Id = 3, Name = "thirdProd", Price = 132.02M},
            };

            return products;
        }
    }
}
