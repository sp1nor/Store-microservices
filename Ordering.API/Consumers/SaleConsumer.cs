using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Models;
using System.Threading.Tasks;

namespace Ordering.API.Consumers
{
    public class SaleConsumer : IConsumer<Shared.Models.Sale>
    {
        private readonly ILogger<Shared.Models.Sale> _logger;

        public SaleConsumer(ILogger<Shared.Models.Sale> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Shared.Models.Sale> context)
        {
            var data = context.Message;
            // update byer history
            _logger.LogInformation("SaleConsumer consumed successfully");
        }
    }
}
