namespace asp.Infrastructure.Applied;
using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : BaseRepository<Course>,ICourseRepository
{
    private readonly AspContext _aspContext;

    public CourseRepository(AspContext aspContext):base(aspContext)
    {
        _aspContext = aspContext;
    }

    public override  IReadOnlyList<Course> GetAll()
    {
        return _aspContext.Courses.Include(x=>x.Student).ToList();
    }
}