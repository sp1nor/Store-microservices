using MassTransit;
using Shared.Models;
using System.Threading.Tasks;

namespace Ordering.API.Consumers
{
    public class SaleConsumer : IConsumer<Shared.Models.Sale>
    {
        public async Task Consume(ConsumeContext<Shared.Models.Sale> context)
        {
            var data = context.Message;
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
    }
}
