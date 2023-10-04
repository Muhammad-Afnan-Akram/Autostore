using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Autostore.Interfaces;
using Autostore.Model;
using Autostore.Repositories;
using MyProject.Data;

namespace Autostore.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AutoStoreContext dbContext) : base(dbContext)
        {
        }

    }

}