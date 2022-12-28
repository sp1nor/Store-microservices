using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

using Sale.API.Entities;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IBus _bus;

        public SaleController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(Sale.API.Entities.Sale sale)
        {
            if (sale != null)
            {
                sale.Date = DateTime.Now;
                Uri uri = new Uri("rabbitmq://localhost/saleQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(sale);
                return Ok();
            }
            return BadRequest();
        }
    }
}
