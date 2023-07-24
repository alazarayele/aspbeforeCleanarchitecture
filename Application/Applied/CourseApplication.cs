namespace asp.Application.Applied;

using System.Collections.Generic;
using asp.Application.Interface;
using asp.Model;
using asp.Data;
using asp.Infrastructure.Interface;
using System.Threading.Tasks;

public class CourseApplication : ICourse
{

    private readonly ICourseRepository _iCourseRepository;

    public CourseApplication(ICourseRepository iCourseRepository)
    {
        _iCourseRepository=iCourseRepository;
    }
    public string Add(Course course)
    {
       return _iCourseRepository.Add(course);
    }

    public string Delete(int id)
    {
        var student = GetById(id);
        return _iCourseRepository.Delete(student);
    }

    public IReadOnlyList<Course> GetAll()
    {
        return _iCourseRepository.GetAll();
    }

    public Course GetById(int id)
    {
        return _iCourseRepository.GetById(id);
    }

   
    public async Task UpdateCourse(Course course, int id)
    {
          var courseTo = _iCourseRepository.GetById(id);
            // if(o == null) 
            // {
                
            // }
           // var newo = student.MapToModel(o);
        courseTo.Name = course.Name;
        courseTo.Description = course.Description;
        courseTo.CreditHour = course.CreditHour;
            
        _iCourseRepository.Update(courseTo);
    }
}