namespace ProductManagement_2.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public Category Category { get; set; }
        public string? Description { get; set; }
    }
}
