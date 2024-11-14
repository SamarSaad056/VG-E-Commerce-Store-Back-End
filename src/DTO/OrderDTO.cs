namespace FusionTech.src.DTO
{
    public class OrderDTO
    {
        public class OrderReadDto()
        {
            public Guid OrderId { get; set; }
            public DateTime OrderDate { get; set; }
            public float TotalPrice { get; set; }
            public Guid PaymentId { get; set; }
            public Guid StoreId { get; set; }
            public int EmployeeId { get; set; }
            public int CustomerId { get; set; }
            public List<OrderedGamesReadDto> OrderedGames { get; set; }
        }

        public class OrderCreateDto()
        {
            public int EmployeeId { get; set; }
            public Guid StoreId { get; set; }
            public Guid PaymentId { get; set; }
            public List<OrderedGamesCreateDto> OrderedGames { get; set; } // Removed the DTO to make things easier
        }

        public class OrderUpdateDto()
        {
            public float TotalPrice { get; set; }
        }

        public class OrderListDto
        {
            public List<OrderReadDto> Orders { get; set; }
            public int TotalCount { get; set; }
        }
    }
}
