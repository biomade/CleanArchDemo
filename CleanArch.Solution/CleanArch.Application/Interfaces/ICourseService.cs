using CleanArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseService
    {
        //this VM returns an IEnumerable
        IEnumerable<CourseViewModel> GetCourses();
        void Create(CourseViewModel courseViewModel);
    }
}
