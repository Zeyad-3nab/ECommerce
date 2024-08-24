using FinalProject.Models;

namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }=null!;
        public double Price { get; set; }
        public string Photo { get; set; } = null!;
        //public int CategoryId { get; set; }
        //public Categoty Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<Cart> Carts { get; set; }   
      
    }
}
