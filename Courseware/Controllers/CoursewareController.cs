using Courseware.Repository.Interface;
using Courseware.Repository.Service;
using LMSAPI.Controllers;
using LMSAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courseware.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CoursewareController
    {
        private ICourseware _coursewareRepo;
        private readonly ILogger<CoursewareController> _logger;

        public CoursewareController(ICourseware coursewareRepo, ILogger<CoursewareController> logger)
        {
            _logger = logger;
            _coursewareRepo = coursewareRepo;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public string StudentEnrollToCourse(int studentId, int courseId)
        {
            _logger.LogInformation("Inside StudentEnrollToCourse method");
            string result = string.Empty;
            try
            {
                _coursewareRepo.AssignCourse(studentId, courseId);
                result = "Student enroll successfully with the course";
            }
            catch (System.Exception ex)
            {
                result = "Some error occured";
                _logger.LogError(ex.Message.ToString());
            }
            return result;
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public List<Course> Catalouge()
        {
            _logger.LogInformation("Inside Catalouge method");
            List <Course> result=new List<Course>();
            try
            {
                result= _coursewareRepo.GetCourse();
            }
            catch (System.Exception ex)
            {
                result = null;
                _logger.LogError(ex.Message.ToString());
            }
            return result;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public bool AddCourse(Course course)
        {
            _logger.LogInformation("Inside AddCourse method");
            bool result= false;
            try
            {
                result=_coursewareRepo.AddCourse(course);
            }
            catch (System.Exception ex)
            {
                result = false;
                _logger.LogError(ex.Message.ToString());
            }
            return result;
        }
        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public bool UpdateCourse(Course course)
        {
            _logger.LogInformation("Inside UpdateCourse method");
            bool result = false;
            try
            {
                _coursewareRepo.UpdateCourse(course);
            }
            catch (System.Exception ex)
            {
                result = false;
                _logger.LogError(ex.Message.ToString());
            }
            return result;
        }
    }
}
