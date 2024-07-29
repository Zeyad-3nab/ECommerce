using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class WishList
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; } = null!;  //Type string       in controller inject to user Manager to get user id 
        public Product? Product { get; set; }
    }
}
