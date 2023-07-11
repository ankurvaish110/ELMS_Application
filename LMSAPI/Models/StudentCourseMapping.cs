using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSAPI.Models
{
    [Table("StudentCourseMapping")]
    public class StudentCourseMapping
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
    }
}
