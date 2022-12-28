using System;
using System.Collections.Generic;

namespace Sale.API.Entities
{
    public class Sale : Entity
    {
        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public int SalesProductId { get; set; }

        public int? BuyerId { get; set; }

        public List<SaleData> SalesData { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
