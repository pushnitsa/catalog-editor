using System.Collections.Generic;

namespace CatalogEditor.DTO
{
    public class Category
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<Category> Childs { get; set; }
    }
}