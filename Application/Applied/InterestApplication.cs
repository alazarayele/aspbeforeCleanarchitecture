namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class InterestApplication : IInterest
{
    private readonly IInterestRepository _interest;

    public InterestApplication(IInterestRepository interest)
    {
        _interest = interest;
    }
     public IReadOnlyList<Interest> GetAll()
    {
        return _interest.GetAll();
    }
    public Interest GetById(int id)
    {
        return _interest.GetById(id);
    }
    public string Add(Interest interest)
    {
        return _interest.Add(interest);
    }
    public string Delete(int id)
    {
        var interestT = GetById(id);
        return _interest.Delete(interestT);
    }
    public Interest Update(Interest interest, int id)
    {

        var interestTo = GetById(id);
        interestTo.Name = interest.Name;
        return _interest.Update(interestTo);
    }

   
}