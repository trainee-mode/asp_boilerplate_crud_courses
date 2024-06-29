using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Courses.Dto;

namespace test123.Courses
{
    public interface ICourseAppService : IApplicationService
    {
        void CreateCourse(CreateCourseDto course);
        IEnumerable<GetAllCourseDto> GetAllCourses();

        GetAllCourseDto GetCourseById(Guid id);

        void UpdateCourse(CourseDto course);

        void DeleteCourse(Guid id);

    }
}
