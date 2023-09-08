﻿using System.ComponentModel.DataAnnotations;

namespace Autostore.Model
{
    public enum EmployeeRole
    {
        Cashier,
        Seller,
        Accountant
    }

    public class Employees
    {
   
        public int EmployeesId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public EmployeeRole Role { get; set; }
        [Required]
        public string Contactno { get; set; }
        public string Address { get; set; }
        public ICollection<BusinessTransactions> BusinessTransactions { get; set; }
    }
}
