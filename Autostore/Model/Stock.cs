using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Autostore.Model
{
    public class Stock
    {
        [Key]
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
        [JsonIgnore]
        public ICollection<StockHistory> StockHistory { get; set; }

    }
}
