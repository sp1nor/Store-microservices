using Shared.Models;
using System.Collections.Generic;

namespace Sale.API.Entities
{
    public class Buyer : Entity
    {
        public string Name { get; set; }

        public List<SalesId> SalesIds { get; set; }
    }
}
