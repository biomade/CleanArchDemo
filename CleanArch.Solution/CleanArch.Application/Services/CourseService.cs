using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _autoMapper;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus, IMapper autoMapper)
        {
            _CourseRepository = courseRepository;
            _bus = bus;
            _autoMapper = autoMapper;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            //uses mediatr command
            //replaced with automapper
            //var createCourseCommand = new CreateCourseCommand(
            //    courseViewModel.Name,
            //    courseViewModel.Descrption,
            //    courseViewModel.ImageUrl
            //    );
            // _bus.SendCommand(createCourseCommand);


            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            //NOTE: use Automapper to simplify this
            //var courses = _CourseRepository.GetCourses();
            //CourseViewModel coursesVM = (CourseViewModel)courses;
            //return coursesVM;

            //replaced with automapper
            //return new CourseViewModel()
            //{
            //    Courses = _CourseRepository.GetCourses()
            //};

            return _CourseRepository.GetCourses().ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);
        }

    }
}
