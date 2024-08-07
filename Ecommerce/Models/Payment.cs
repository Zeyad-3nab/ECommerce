using FinalProject.Models;

namespace Ecommerce.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public double Total { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

    }
}
