namespace Raktarkezelo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public int SupplierId { get; set; }
    }
}
