using Ecommerce.Models;

namespace Ecommerce.ViewModels
{
    public class CartVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
