using asp.Data;
using asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.Application.Interface;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    // private readonly AspContext _aspContext;
    // public CourseController(AspContext aspContext)
    // {
    //     _aspContext=aspContext;
    // }

 private readonly ICourse _iCourse;
    public CourseController(ICourse iCourse)
    {
        _iCourse=iCourse;
    }

    [HttpGet]
    public List<Course> GetCourses()
    {
        return _iCourse.GetAll().ToList();
    }

    [HttpPost]
    public string AddCourse(Course course)
    {
       return _iCourse.Add(course);
    }
      [HttpGet("{id}")]
    public Course GetCourses(int id)
    {
        return _iCourse.GetById(id);
    }

    [HttpDelete("{id}")]
    public string DeleteCourse(int id)
    {
        return _iCourse.Delete(id);
    }

    //  [HttpPut("{id}")]
    // public string UpdateCourse(Course courses,int id)
    // {
    //   Course course=GetCourses(id);
    //    if(course != null)
    //         {
    //             course.Name = courses.Name;
    //             course.Description = courses.Description;
    //             course.CreditHour = courses.CreditHour;

    //              _aspContext.SaveChangesAsync();
    //               return "Updated";
    //      }
    //      else
    //      return "notUpdate";
       
       
    //}
}