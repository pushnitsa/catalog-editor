namespace CatalogEditor.Models
{
    public class Product
    {
        
        public int Id { get; private set; }
        
        public string Name { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
        
        public Category Category { get; set; }
        
        public int CategoryId { get; set; }
    }
}