using Autostore.Interfaces;
using Autostore.Model;
using MyProject.Data;

namespace Autostore.Repositories
{
    public class CustomerTransactionsRepository : GenericRepository<CustomerTransactions>, ICustomerTransactionsRepository
    {
        public CustomerTransactionsRepository(AutoStoreContext dbContext) : base(dbContext)
        {
        }
    }
}
