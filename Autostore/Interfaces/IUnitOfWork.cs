using System;
using System.Threading.Tasks;

namespace Autostore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       /* ICompanyRepository CompanyRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICustomerTransactionRepository CustomerTransactionRepository { get; }*/
        IEmployeeRepository EmployeeRepo { get; }
        /*IProductRepository ProductRepository { get; }
        IProductTransactionRepository ProductTransactionRepository { get; }
        IStockRepository StockRepository { get; }
        IStockHistoryRepository StockHistoryRepository { get; }*/

        void Save();
    }
}
