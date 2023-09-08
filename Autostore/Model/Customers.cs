using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autostore.Model
{
    public class Customer
    {
   
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DueAmount { get; set; }
        public ICollection<BusinessTransactions> BusinessTransactions { get; set; }
    }
}