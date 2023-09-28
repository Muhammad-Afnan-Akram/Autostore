using Autostore.Interfaces;
using Autostore.Model;
using MyProject.Data;

namespace Autostore.Repositories
{
    public class ProductTransactionRepository : GenericRepository<ProductTransaction>, IProductTransactionRepository
    {
        public ProductTransactionRepository(AutoStoreContext dbContext) : base(dbContext)
        {
        }
    }
}
