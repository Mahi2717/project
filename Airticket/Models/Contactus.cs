using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Airticket.Models
{
    [Table("Contactus")]
    public class Contactus
    {
        [Key]
        public int Cid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
