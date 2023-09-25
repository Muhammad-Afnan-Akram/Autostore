using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Autostore.Model
{
    public class Product
    {

        public int ProductId { get; set; }  

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchaseCost { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProfitPercentage { get; set; }


        //[JsonIgnore]
        
        public ICollection<ProductTransaction> ProductTransactions { get; set; }
        public ICollection<Stock> Stock { get; set; }


    }
}
