using Microsoft.AspNetCore.Mvc;
using Ordering.API.Entities;
using Ordering.API.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly IGenericRepository<Buyer> _repository;

        public BuyerController(IGenericRepository<Buyer> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var buyer = _repository.GetAll();
            return Ok(buyer);
        }

        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Buyer buyer)
        {
            _repository.Create(buyer);

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
        public async Task<IActionResult> Update(Buyer buyer)
        {
            _repository.Update(buyer);

            return Ok();
        }
    }
}
