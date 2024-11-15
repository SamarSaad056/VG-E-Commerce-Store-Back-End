namespace FusionTech.src.Entity
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public float TotalPrice { get; set; }

        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        public Guid StoreId { get; set; }

        [ForeignKey("StoreEmployee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public ICollection<OrderedGames> OrderedGames { get; set; }
    }
}
