using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test123.Courses.Dto;

namespace test123.Courses
{
    public class CourseAppService : ApplicationService, ICourseAppService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseAppService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public void CreateCourse(CreateCourseDto course)
        {
            var newCourse = _courseRepository.FirstOrDefault(p => p.Title == course.Description);
            if (newCourse != null)
            {
                throw new UserFriendlyException("Already exists");
            }

            newCourse = new Course { Title = course.Title, Description = course.Title };
            _courseRepository.Insert(newCourse);
        }

        public IEnumerable<GetAllCourseDto> GetAllCourses()
        {
            var getCourses = _courseRepository.GetAll().ToList();

            var courses = ObjectMapper.Map<List<GetAllCourseDto>>(getCourses);
            return courses;
        }

        public GetAllCourseDto GetCourseById(Guid id)
        {
            var course = _courseRepository.GetAll().FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new EntityNotFoundException(typeof(Course), id);
            }
            var courseDto = ObjectMapper.Map<GetAllCourseDto>(course);
            return courseDto;
        }

        public void UpdateCourse(CourseDto courseDto)
        {
            var course = _courseRepository.GetAll().FirstOrDefault(c => c.Id == courseDto.Id);
            if (course == null)
            {
                throw new EntityNotFoundException(typeof(Course), courseDto.Id);
            }
            course.Title = courseDto.Title;
            course.Description = courseDto.Description;

            _courseRepository.Update(course); 
            CurrentUnitOfWork.SaveChanges(); 
        }

        public void DeleteCourse(Guid id)
        {
            var course = _courseRepository.GetAll().FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new EntityNotFoundException(typeof(Course), id);
            }
            _courseRepository.Delete(course);
            CurrentUnitOfWork.SaveChanges();

        }
    }
}
