namespace asp.Application.Interface;
using asp.Model;

public interface IPersons

{
    IReadOnlyList<Person> GetAll();

    Person GetById(int id);

    string Add(Person person);

    string Delete(int id);

    Person Update(Person person,int id);
}