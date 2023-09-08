using System.ComponentModel.DataAnnotations;

namespace Autostore.Model
{
    public enum PaymentTerms
    {
        Net15,
        Net30,
        Net45,
        Net60
    }
    public class Company
    {

        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public PaymentTerms Terms { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

     
        public ICollection<Products> Products { get; set; }
        public ICollection<BusinessTransactions> BusinessTransactions { get; set; }
    }
}
