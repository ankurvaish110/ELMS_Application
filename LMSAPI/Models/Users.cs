using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSAPI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public int IsActive { get; set; }
        [NotMapped]
        public string AccessToken { get; set; }
    }
}
