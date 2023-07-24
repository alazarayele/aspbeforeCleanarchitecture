namespace asp.Application.Applied;

using System.Collections.Generic;
using asp.Application.Interface;
using asp.Model;
using asp.Infrastructure.Interface;

public class EmployeeApplication : IEmployee

{

    private readonly IEmployeeRepository _iEmployeeRepository;

    public EmployeeApplication(IEmployeeRepository iEmployeeRepository)
    {
        _iEmployeeRepository=iEmployeeRepository;
    }
    public string Add(Employee employee)
    {
        return _iEmployeeRepository.Add(employee);
    }

    public string Delete(int id)
    {
        var employee = GetById(id);
        return _iEmployeeRepository.Delete(employee);
    }

    public IReadOnlyList<Employee> GetAll()
    {
        return _iEmployeeRepository.GetAll();
    }

    public Employee GetById(int id)
    {
        return _iEmployeeRepository.GetById(id);
    }

    public string Update(Employee employee)
    {
        throw new NotImplementedException();
    }
}