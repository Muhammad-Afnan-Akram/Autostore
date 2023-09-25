using System;
using System.Threading.Tasks;
using Autostore.Data.Repositories;
using Autostore.Interfaces; 
using MyProject.Data;

namespace Autostore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepo { get; }
        private readonly AutoStoreContext _dbContext;

        public UnitOfWork(AutoStoreContext dbContext)
        {
            _dbContext = dbContext;
            EmployeeRepo=new EmployeeRepository(dbContext);
            
        }

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
