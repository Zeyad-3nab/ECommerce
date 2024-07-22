namespace FinalProject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Messege { get; set; }
    }
}
