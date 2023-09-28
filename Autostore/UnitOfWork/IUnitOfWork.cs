using System;
using System.Threading.Tasks;
using Autostore.Interfaces;

namespace Autostore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepo { get; }
        ICustomerRepository CustomerRepo { get; }
        ICustomerTransactionRepository CustomerTransactionRepo { get; }
        IEmployeeRepository EmployeeRepo { get; }
        IProductRepository ProductRepo { get; }
        IProductTransactionRepository ProductTransactionRepo { get; }
        IStockRepository StockRepo { get; }
        IStockHistoryRepository StockHistoryRepo { get; }

        void Save();
    }
}
