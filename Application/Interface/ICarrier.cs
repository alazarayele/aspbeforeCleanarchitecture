namespace asp.Application.Interface;
using asp.Model;

public interface Icarrier

{
    IReadOnlyList<Career> GetAll();

    Career GetById(int id);

    string Add(Career career);

    string Delete(int id);

    Career Update(Career career,int id);
}