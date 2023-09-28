using Autostore.Interfaces;
using Autostore.Model;
using MyProject.Data;

namespace Autostore.Repositories
{
    public class StockHistoryRepository : GenericRepository<StockHistory>, IStockHistoryRepository
    {
        public StockHistoryRepository(AutoStoreContext dbContext) : base(dbContext)
        {
        }
    }
}
