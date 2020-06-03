using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _CourseRepository;
        private readonly IMediatorHandler _bus;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus)
        {
            _CourseRepository = courseRepository;
            _bus = bus;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            //uses mediatr
            var createCourseCommand = new CreateCourseCommand(
                courseViewModel.Name,
                courseViewModel.Descrption,
                courseViewModel.ImageUrl
                );

            _bus.SendCommand(createCourseCommand);
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
