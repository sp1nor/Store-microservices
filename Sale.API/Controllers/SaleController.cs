using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Shared.Models;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public SaleController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(SaleCheckoutEvent sale)
        {
            await _publishEndpoint.Publish<SaleCheckoutEvent>(sale);

            return Accepted();
        }
    }
}
