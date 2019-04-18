using System.ComponentModel.DataAnnotations.Schema;

namespace EF_UseCases
{
    [Table("Retail", Schema = "BusinessContext")]
    public class Retail : Business
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIPCode { get; set; }
    }
}
