using ProdutoMS.Repositories.Base;

namespace ProdutoMS.Repositories
{
    public interface IProductRepository : IAsyncRepository<Models.Product>
    {
        
    }
}