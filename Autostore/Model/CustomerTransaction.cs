using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autostore.Model
{


    public enum PaymentStatus
    {
        Paid,
        Unpaid
    }

    public class CustomerTransaction
    {
    
        public int CustomerTransactionId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountPaid { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        public ICollection<ProductTransaction> ProductTransaction { get; set; }
    }
}
