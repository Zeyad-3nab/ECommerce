using Ecommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Range(1,50)]
        public int Quantity { get; set; }
        public string UserId { get; set; } = null!;  //Type string       in controller inject to user Manager to get user id 
        public Product? Product { get; set; }
    }
}
