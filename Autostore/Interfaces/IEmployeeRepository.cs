using Autostore.Model;

namespace Autostore.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        public IQueryable<CustomerTransaction> GetTransactionsManagedByEmployee(string employeeName);
    }
}
