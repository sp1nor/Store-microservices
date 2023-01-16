using CatalogService.API.Entities;
using CatalogService.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository repository,
                                 ILogger<ProductController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = _repository.GetAll();
            _logger.LogInformation("Get product form repository successfully.", products);
            return Ok(products);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = _repository.GetItemById(id);
            return Ok(product);
        }

        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _repository.Create(product);

            return Ok();
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            _repository.Delete(id);

            return Ok();
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        //[HttpPut("{id}")]
        [HttpPut]
        //public async Task<IActionResult> Update(int id, Product product)
        public async Task<IActionResult> Update(Product product)
        {
            _repository.Update(product);

            return Ok();
        }
    }
}
