using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Autostore.Model
{
    
    public class Company
    {

        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Contact { get; set; }

        public string Address { get; set; }


    }
}
