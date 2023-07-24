namespace asp.Application.Interface;
using asp.Model;
public interface ICountry
{
     IReadOnlyList<Country> GetAll();

    Country GetById(int id);

    string Add(Country country);

    string Delete(int id);

    string Update(int id);
}