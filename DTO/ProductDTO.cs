namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }

        public string Des { get; set; } = null!;

        public string? Image { get; set; }
    }
}