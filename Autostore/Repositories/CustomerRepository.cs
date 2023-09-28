using Autostore.Interfaces;
using Autostore.Model;
using MyProject.Data;

namespace Autostore.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AutoStoreContext dbContext) : base(dbContext)
        {
        }
    }
}
