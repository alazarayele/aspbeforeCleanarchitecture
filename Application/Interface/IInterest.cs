namespace asp.Application.Interface;
using asp.Model;

public interface IInterest

{
    IReadOnlyList<Interest> GetAll();

    Interest GetById(int id);

    string Add(Interest interest);

    string Delete(int id);

    Interest Update(Interest interest, int id);
}