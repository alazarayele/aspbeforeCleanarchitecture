namespace asp.Infrastructure.Applied;
using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : BaseRepository<Employee>,IEmployeeRepository
{


private readonly AspContext _aspContext;

public EmployeeRepository(AspContext aspContext):base(aspContext)
{
    _aspContext=aspContext;
}

public override IReadOnlyList<Employee>GetAll()
{
    return _aspContext.Employees.Include(x=>x.EmployeeProjects).ToList();
}
}


