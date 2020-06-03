using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _CourseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _CourseRepository = courseRepository;
        }       

        CourseViewModel ICourseService.GetCourses()
        {
            //NOTE: use Automapper to simplify this
            //var courses = _CourseRepository.GetCourses();
            //CourseViewModel coursesVM = (CourseViewModel)courses;
            //return coursesVM;

            return new CourseViewModel()
            {
                Courses = _CourseRepository.GetCourses()
            };
        }
    }
}
