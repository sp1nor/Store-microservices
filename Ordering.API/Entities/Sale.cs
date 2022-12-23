using System;

namespace Ordering.API.Entities
{
    public class Sale : Entity
    {
        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public int SalesProductId { get; set; }

        public int? BuyerId { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
