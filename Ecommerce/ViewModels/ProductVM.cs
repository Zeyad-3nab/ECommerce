using FinalProject.Models;

namespace Ecommerce.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public int BrandId { get; set; }
    }
}
