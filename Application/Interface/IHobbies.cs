namespace asp.Application.Interface;
using asp.Model;

public interface IHobbies

{
    IReadOnlyList<Hobby> GetAll();

    Hobby GetById(int id);

    string Add(Hobby hobby);

    string Delete(int id);

    Hobby Update(Hobby hobby, int id);
}