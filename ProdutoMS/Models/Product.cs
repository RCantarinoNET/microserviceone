using ProdutoMS.Repositories.Base;

namespace ProdutoMS.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public int CategoryID { get; set; }
        
        public Category Category { get; set; }
    }
}