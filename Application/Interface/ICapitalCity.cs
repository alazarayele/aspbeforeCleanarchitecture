namespace asp.Application.Interface;
using asp.Model;

public interface ICapitalCity

{
    IReadOnlyList<CapitalCity> GetAll();

    CapitalCity GetById(int id);

    string Add(CapitalCity capitalCity);

    string Delete(int id);

    string Update(int id);
}