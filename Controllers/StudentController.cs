using asp.Data;
using asp.Model;
using asp.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp.Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace asp.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]

public class StudentController : ControllerBase
{
    private readonly IStudent _istudent;
   
    public StudentController(IStudent istudent)
    {
        _istudent=istudent;
        

    }


    // [HttpGet]
    // public List<Student> GetStudents(){
    //     return _aspContext.Students.ToList();
    // }

   
   
     [HttpGet]
    public List<Student> GetStudents(){
        return (List<Student>)_istudent.GetAll();
        
    }


    [HttpPost]
    public string AddStudent(Student student)
    {
        return _istudent.Add(student);
       
        
    }

   [HttpDelete("{id}")]
   
   public string DeleteStudent(int id)
   {
   
        _istudent.Delete(id);
   
    return "Deleted";

   }

    
   
  

    [HttpGet("{id}")]
    public ActionResult<Student> GetStudent(int id)
    {
        var stu = _istudent.GetById(id);
        if (stu == null)
        {
           return NotFound();
        }
        else
        {
            return stu;
        }
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBookAsyncEasy(Student student, int id)
    {
        await _istudent.UpdateBookAsyncEasy(student, id);
        
        return NoContent();    
    }
}