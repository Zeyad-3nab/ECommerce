using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class CartVM
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int ProductId { get; set; }

       
        public int Quantity { get; set; }
    }
}
