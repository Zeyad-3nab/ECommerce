using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class WishListVM
    {

        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int ProductId { get; set; }

       
    }
}
