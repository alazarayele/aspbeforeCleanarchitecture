namespace asp.Application.Interface;
using asp.Model;
public interface ICourse
{
    IReadOnlyList<Course> GetAll();

    Course GetById(int id);

    string Add(Course course);

    string Delete(int id);

    string Update(int id);
}