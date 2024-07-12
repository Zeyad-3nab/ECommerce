namespace FinalProject.Models
{
    public class Categoty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public List<Product> Products { get; set; }
    }
}
