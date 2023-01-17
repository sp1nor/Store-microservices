using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sale.API.Entities;
using Sale.API.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesPointController : ControllerBase
    {
        private readonly ISalesPointRepository _repository;
        private readonly ILogger<SalesPointController> _logger;

        public SalesPointController(ISalesPointRepository repository,
                                    ILogger<SalesPointController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesPoints = _repository.GetAll();

            _logger.LogInformation("Get salesPoint form repository successfully.", salesPoints);
            return Ok(salesPoints);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var salesPoint = _repository.GetItemById(id);
            return Ok(salesPoint);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesPoint salesPoint)
        {
            _repository.Create(salesPoint);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SalesPoint salesPoint)
        {
            _repository.Update(salesPoint);

            return Ok();
        }
    }
}
