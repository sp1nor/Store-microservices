﻿using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Sale.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        //private readonly IBus _bus;

        //public SaleController(IBus bus)
        //{
        //    _bus = bus;
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateSale(Shared.Models.Sale sale)
        //{
        //    if (sale != null)
        //    {
        //        sale.Date = DateTime.Now;
        //        Uri uri = new Uri("rabbitmq://localhost/saleQueue");
        //        var endPoint = await _bus.GetSendEndpoint(uri);
        //        await endPoint.Send(sale);
        //        return Ok();
        //    }
        //    return BadRequest();
        //}

        public SaleController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] Shared.Models.Sale sale)
        {
            await _publishEndpoint.Publish(sale);

            return Accepted();
        }
    }
}