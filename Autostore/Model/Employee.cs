using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Autostore.Model
{
    public enum EmployeeRole
    {
        Cashier,
        Seller,
        Accountant
    }

    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public EmployeeRole Role { get; set; }
        [Required]
        public string? Contactno { get; set; }
        public string? Address { get; set; }

        [JsonIgnore]
        public ICollection<CustomerTransactions>? CustomerTransactions { get; set; }
    }
}
