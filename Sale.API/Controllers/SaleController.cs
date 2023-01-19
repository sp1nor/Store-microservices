using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Shared.Models;
using Sale.API.Persistence.Repositories;
using Microsoft.Extensions.Logging;
using Sale.API.Features;
using System.Linq;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISalesPointRepository _repositorySalesPoint;
        private readonly ISaleRepository _repositorySale;
        private readonly ILogger<SalesPointController> _logger;
        private readonly ISaleFeature _saleFeature;
        private readonly IPublishEndpoint _publishEndpoint;

        public SaleController(
            ISaleFeature saleFeature,
            IPublishEndpoint publishEndpoint,
            ISalesPointRepository repositorySalesPoint,
            ISaleRepository repositorySale,
            ILogger<SalesPointController> logger
            )
        {
            _saleFeature = saleFeature;
            _publishEndpoint = publishEndpoint;
            _repositorySalesPoint = repositorySalesPoint;
            _repositorySale = repositorySale;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = _repositorySale.GetAll();

            _logger.LogInformation("Get Sales form repository successfully.", sales);
            return Ok(sales);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(Shared.Models.Sale sale)
        {
            var salesPoint = _repositorySalesPoint.GetItemById(sale.Id);

            var isCorrectProductQuantity = SaleFeature.isProductQuantityLessThenHaveSalePoint(sale, salesPoint);

            if (!isCorrectProductQuantity)
            {
                _logger.LogInformation("Not correct product quantity in sale.", sale);
                return BadRequest();
            }

            _logger.LogInformation("Correct product quantity in sale.", sale);

            var saleWithTotalAmount = await _saleFeature.CalculateTotalAmount(sale);

            UpdateProductQuantityInSalesPoint(sale, salesPoint);

            _repositorySale.Create(sale);

            await _publishEndpoint.Publish<Shared.Models.Sale>(sale);

            return Accepted();
        }

        private void UpdateProductQuantityInSalesPoint(Shared.Models.Sale sale, Entities.SalesPoint salesPoint)
        {
            foreach (var providedProduct in salesPoint.ProvidedProducts)
            {
                var currentProduct = sale.SalesData.FirstOrDefault(d => d.ProductId == providedProduct.ProductId);
                providedProduct.ProductQuantity -= currentProduct.ProductQuantity;
            }
            _repositorySalesPoint.Update(salesPoint);
        }
    }
}
