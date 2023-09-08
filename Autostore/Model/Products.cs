using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autostore.Model
{
    public class Products
    {

        public int ProductsId { get; set; }  

        [Required]
        public string Name { get; set; }

        public Company Company { get; set; }
        [Required]
        public int CompanyID { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int QuantityInStock { get; set; }
        public ICollection<ProductTransactions> ProductTransactions { get; set; }


    }
}
