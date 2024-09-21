namespace Domain.Models
{
    public class OrderHistory
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Status { get; set; }
        public DateTime? PaymentDate { get; set; }

        public decimal PaymentAmount { get; set; }

        public string? PaymentMethod { get; set; }
        public string ProductName { get; set; } = null!;

        public string? ProductDescription { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
