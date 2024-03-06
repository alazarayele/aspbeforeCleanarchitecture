namespace asp.Application.Interface;
using asp.Model;

public interface IProficiency

{
    IReadOnlyList<Proficiency> GetAll();

    Proficiency GetById(int id);

    string Add(Proficiency proficiency);

    string Delete(int id);

    Proficiency Update(Proficiency proficiency, int id);
}