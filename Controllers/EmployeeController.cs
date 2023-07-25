using asp.Data;
using asp.Model;
using asp.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    // private readonly AspContext _aspContext;

    // public EmployeeController(AspContext aspContext)
    // {
    //         _aspContext=aspContext;
    // }


    // [HttpGet]
    // public List<Employee> GetEmployees()
    // {
    //     return _aspContext.Employees.Include(x=>x.EmployeeProjects).ToList();
     
    // }

    // [HttpPost]
    // public string AddEmployess(Employee employee)
    // {
    //     _aspContext.Employees.Add(employee);
    //     _aspContext.SaveChanges();
    //     return "ok";
    // }

    // [HttpGet("{id}")]

    // public Employee GetEmployee(int id)
    // {
    //     return _aspContext.Employees.SingleOrDefault(employee=>employee.Id==id);
    // }

    // [HttpDelete("{id}")]
    // public string DeletEmployee(int id)
    // {
    //     Employee employee=GetEmployee(id);
    //     _aspContext.Employees.Remove(employee);
    //     _aspContext.SaveChanges();
    //     return "Deleted";

    // }

    // [HttpPut("{id}")]
    //  public string UpdateEmployee(Employee employee,int id)
    //  {
    //    Employee employee1=GetEmployee(id);
    //     if(employee1 != null)
    //          {
    //              employee1.FirstName = employee.FirstName;
    //              employee1.LastName = employee.LastName;
    //              employee1.Salary = employee.Salary;
    //               _aspContext.SaveChanges();
    //                return "Updated";
    //       }
    //       else
    //       return "notUpdate";
       
       
    // }

    private readonly IEmployee _iEmployee;

    public EmployeeController(IEmployee iEmployee)

    {
        _iEmployee=iEmployee;

    }

    [HttpGet]
    public List<Employee>GetEmployees()
    {
        return _iEmployee.GetAll().ToList();
    }

    [HttpPost]
    public string AddEmployess(Employee employee)
    {
        return _iEmployee.Add(employee);
    }

    [HttpGet("{id}")]
    public Employee GetEmployee(int id)
    {
        return _iEmployee.GetById(id);
    }

    [HttpDelete]
    public string DeletEmployee(int id)
    {
        
        return _iEmployee.Delete(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Employee employee,int id)
    {
         _iEmployee.Update(employee,id);
        
        return Ok();
    }

}