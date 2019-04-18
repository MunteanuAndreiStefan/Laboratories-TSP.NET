using System.ComponentModel.DataAnnotations.Schema;

namespace EF_UseCases
{
    [Table("eCommerce", Schema = "BusinessContext")]
    public class eCommerce : Business
    {
        public string URL { get; set; }
    }
}
