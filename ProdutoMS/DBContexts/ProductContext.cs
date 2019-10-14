using Microsoft.EntityFrameworkCore;

namespace ProdutoMS.DBContexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}