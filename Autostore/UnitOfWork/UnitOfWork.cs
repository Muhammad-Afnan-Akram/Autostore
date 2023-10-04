using System;
using System.Threading.Tasks;
using Autostore.Interfaces;
using MyProject.Data;

namespace Autostore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {


        private readonly AutoStoreContext _dbContext;

        public UnitOfWork(AutoStoreContext dbContext, IEmployeeRepository _EmployeeRepo, ICompanyRepository _CompanyRepo, ICustomerRepository _CustomerRepo, ICustomerTransactionsRepository _CustomerTransactionsRepo, IProductTransactionRepository _ProductTransactionRepo, IProductRepository _ProductRepo, IStockRepository _StockRepo, IStockHistoryRepository _StockHistoryRepo)
        {
            _dbContext = dbContext;
            EmployeeRepo = _EmployeeRepo;
            CompanyRepo = _CompanyRepo;
            CustomerRepo = _CustomerRepo;
            CustomerTransactionsRepo = _CustomerTransactionsRepo;
            ProductTransactionRepo = _ProductTransactionRepo;
            StockHistoryRepo = _StockHistoryRepo;
            StockRepo = _StockRepo;
            ProductRepo = _ProductRepo;

        }


        public IEmployeeRepository EmployeeRepo { get; }
        public ICompanyRepository CompanyRepo { get; }
        public ICustomerRepository CustomerRepo { get; }
        public ICustomerTransactionsRepository CustomerTransactionsRepo { get; }
        public IProductTransactionRepository ProductTransactionRepo { get; }
        public IProductRepository ProductRepo { get; }
        public IStockRepository StockRepo { get; }
        public IStockHistoryRepository StockHistoryRepo { get; }


        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
