using Microsoft.AspNetCore.Mvc;
using Ordering.API.Entities;
using Ordering.API.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IGenericRepository<Sale> _repository;

        public SaleController(IGenericRepository<Sale> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sale = _repository.GetAll();
            return Ok(sale);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sale sale)
        {
            _repository.Create(sale);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Sale sale)
        {
            _repository.Update(sale);

            return Ok();
        }
    }
}
