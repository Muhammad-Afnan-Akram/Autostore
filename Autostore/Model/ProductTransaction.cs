using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autostore.Model
{
    public class ProductTransaction
    {
        [Key]
        public int ProductTransactionId { get; set; }

        public int CustomerTransactionId { get; set; }
        public CustomerTransactions? CustomerTransactions { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }

  
        

   
    }
}
 