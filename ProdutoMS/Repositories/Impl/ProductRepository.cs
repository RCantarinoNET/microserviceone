using ProdutoMS.DBContexts;

namespace ProdutoMS.Repositories.Impl
{
    public class ProductRepository  :  Base.EfRepository<Models.Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}