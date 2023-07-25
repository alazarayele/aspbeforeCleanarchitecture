namespace asp.Application.Applied;

using System.Collections.Generic;
using asp.Application.Interface;
using asp.Model;
using asp.Data;
using asp.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

public class StudentApplication : IStudent
{
    private readonly IStudentRepository _iStudentRepository;
    public StudentApplication(IStudentRepository studentRepository)
    {
        _iStudentRepository=studentRepository;
    }
    public string Add(Student student)
    {
        return _iStudentRepository.Add(student);
        
    }

    public string Delete(int id)
    {
        var student=GetById(id);
       return _iStudentRepository.Delete(student);
    }

   public async Task UpdateBookAsyncEasy(Student student, int id)
    {


        var studentTo = _iStudentRepository.GetById(id);
            // if(o == null) 
            // {
                
            // }
           // var newo = student.MapToModel(o);
        studentTo.Name = student.Name;
        studentTo.Gender = student.Gender;
            
         _iStudentRepository.Update(studentTo);
      
    }
   
   


    public IReadOnlyList<Student> GetAll()
    {
        return _iStudentRepository.GetAll();
    }

    public Student GetById(int id)
    {
       return _iStudentRepository.GetById(id);
    }

   
}