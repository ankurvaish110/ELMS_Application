using LMSAPI.Models;
using System.Collections.Generic;

namespace Courseware.Repository.Interface
{
    public interface ICourseware
    {
        bool AssignCourse(int studentId, int courseId);
        List<Course> GetCourse();
        bool UpdateCourse(Course course);
        bool AddCourse(Course course);
    }
}
