using Courseware.Repository.Interface;
using LMSAPI.DAL;
using LMSAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace Courseware.Repository.Service
{
    public class CoursewareRepo : ICourseware
    {
        public ApplicationDbContext _dbContext;
        public CoursewareRepo(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public bool AssignCourse(int studentId, int courseId)
        {
            StudentCourseMapping studentCourseEnroll = new StudentCourseMapping();
            studentCourseEnroll.StudentId = studentId;
            studentCourseEnroll.CourseId = courseId;
            studentCourseEnroll.IsActive = true;
            _dbContext.Entry(studentCourseEnroll).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _dbContext.SaveChanges();
            return true;
        }
        public List<Course> GetCourse()
        {
            return _dbContext.Course.ToList();
        }
        public bool UpdateCourse(Course course)
        {
            Course courseEntity = _dbContext.Course.FirstOrDefault(t => t.Id == course.Id);
            if (courseEntity != null)
            {
                courseEntity.Duration = course.Duration;
                courseEntity.SubTopics = course.SubTopics;
                courseEntity.IsApproved = course.IsApproved;
                courseEntity.Name = course.Name;
                courseEntity.Content = course.Content;
                _dbContext.Entry(courseEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            return true;
        }
        public bool AddCourse(Course course)
        {
            Course courseEntity = new Course();
            courseEntity.Duration = course.Duration;
            courseEntity.SubTopics = course.SubTopics;
            courseEntity.IsApproved = course.IsApproved;
            courseEntity.Name = course.Name;
            courseEntity.Content = course.Content;
            _dbContext.Entry(courseEntity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
