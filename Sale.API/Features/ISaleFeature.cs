using System.Threading.Tasks;
using Shared.Models;

namespace Sale.API.Features
{
    public interface ISaleFeature
    {
        Task<Shared.Models.Sale> CalculateTotalAmount(Shared.Models.Sale sale);
    }
}
