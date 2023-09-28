using Autostore.Interfaces;
using Autostore.Model;
using MyProject.Data;

namespace Autostore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AutoStoreContext dbContext) : base(dbContext)
        {
        }
    }
}
