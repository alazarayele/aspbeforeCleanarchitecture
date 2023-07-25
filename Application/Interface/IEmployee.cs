namespace asp.Application.Interface;
using asp.Model;

public interface IEmployee
{
    IReadOnlyList<Employee> GetAll();

    Employee GetById(int id);

    string Add(Employee employee);

    string Delete(int id);

    Employee Update (Employee employee,int id);
}