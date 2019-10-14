using ProdutoMS.DBContexts;
using ProdutoMS.Repositories.Interfaces;

namespace ProdutoMS.Repositories.Impl
{
    public class CategoryRepository :  Base.EfRepository<Models.Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext context) : base(context) {}
    }
}