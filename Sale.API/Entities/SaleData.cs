namespace Ordering.API.Entities
{
    public class SaleData : Entity
    {
        public int ProductId { get; set; }

        public int ProductQuantity { get; set; }

        public decimal ProductIdAmount { get; set; }
    }
}
