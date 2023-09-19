namespace BookStoreApi.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quant { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
    }
}
