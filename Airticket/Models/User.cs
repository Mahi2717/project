using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Airticket.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }



        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public string Mobile { get; set; }



    }
}
