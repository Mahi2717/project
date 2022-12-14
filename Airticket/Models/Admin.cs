using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Airticket.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
