using System.Collections.Generic;

namespace Sale.API.Entities
{
    public class SalesPoint : Entity
    {
        public string Name { get; set; }

        public List<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
