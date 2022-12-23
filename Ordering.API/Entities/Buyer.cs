using System.Collections.Generic;

namespace Ordering.API.Entities
{
    public class Buyer : Entity
    {
        public string Name { get; set; }

        public List<int> SalesIds { get; set; }
    }
}
