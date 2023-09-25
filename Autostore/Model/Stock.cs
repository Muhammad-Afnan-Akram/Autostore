using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autostore.Model
{
    public class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }  
        public Product Product { get; set; }    
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }




        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountPaid { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<StockHistory> StockHistory { get; set; }

    }
}
