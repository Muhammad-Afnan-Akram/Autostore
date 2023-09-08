using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autostore.Model
{

    public enum TransactionType
    {
        Purchase,
        Sale
    }

    public enum PaymentStatus
    {
        Paid,
        Unpaid
    }

    public class BusinessTransactions
    {
    
        public int BusinessTransactionsId { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public int PartnerID { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employees Employee { get; set; }
      
        public Customer Customer { get; set; }

        public Company Company { get; set; }
        public ICollection<ProductTransactions> ProductTransactions { get; set; }
    }
}
