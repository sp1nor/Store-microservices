using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Models;
using System.Threading.Tasks;

namespace Ordering.API.Consumers
{
    public class SaleConsumer : IConsumer<SaleCheckoutEvent>
    {
        private readonly ILogger<SaleCheckoutEvent> _logger;

        public SaleConsumer(ILogger<SaleCheckoutEvent> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SaleCheckoutEvent> context)
        {
            var data = context.Message;

            _logger.LogInformation("SaleConsumer consumed successfully");
        }
    }
}
