using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSAPI.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Content { get; set; }
        public int IsApproved { get; set; }
        public string SubTopics { get; set; }
    }
}
