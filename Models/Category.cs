using System.Collections.Generic;

namespace CatalogEditor.Models
{
    public class Category
    {

        public Category()
        {
            Childs = new List<Category>();
        }
        
        public int Id { get; private set; }
        
        public string Name { get; set; }
        
        public ICollection<Category> Childs { get; set; }
        
        public int? CategoryId { get; set; }
    }
}