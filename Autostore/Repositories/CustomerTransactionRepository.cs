using Autostore.Interfaces;
using Autostore.Model;
using MyProject.Data;

namespace Autostore.Repositories
{
    public class CustomerTransactionRepository : GenericRepository<CustomerTransaction>, ICustomerTransactionRepository
    {
        public CustomerTransactionRepository(AutoStoreContext dbContext) : base(dbContext)
        {
        }
    }
}
