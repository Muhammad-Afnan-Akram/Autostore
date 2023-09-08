using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autostore.Model
{
    public class ProductTransactions
    {
        public int BusinessTransactionsId { get; set; }
        public BusinessTransactions BusinessTransaction { get; set; }

        public int ProductId { get; set; }
        public Products Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
