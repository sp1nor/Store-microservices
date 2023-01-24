using MassTransit;
using Microsoft.Extensions.Logging;
using Sale.API.Entities;
using Sale.API.Persistence.Repositories;
using Shared.Models;
using System.Threading.Tasks;

namespace Ordering.API.Consumers
{
    public class SaleConsumer : IConsumer<Shared.Models.Sale>
    {
        private readonly ILogger<Shared.Models.Sale> _logger;
        private readonly IGenericRepository<Buyer> _repository;

        public SaleConsumer(
            ILogger<Shared.Models.Sale> logger,
            IGenericRepository<Buyer> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task Consume(ConsumeContext<Shared.Models.Sale> context)
        {
            var sale = context.Message;
            
            // update byer
            if (sale.BuyerId.Value != null)
            {
                var currentBuyer = _repository.GetById(sale.BuyerId.Value);
                var salesId = new SalesId() { Id = sale.Id };
                currentBuyer.SalesIds.Add(salesId);

                _repository.Update(currentBuyer);

                _logger.LogInformation("Add sale Id to current buyer successfully");
            }

            _logger.LogInformation("SaleConsumer consumed successfully");
        }
    }
}
