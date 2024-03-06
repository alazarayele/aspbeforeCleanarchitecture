namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class HobbyApplication : IHobbies
{
    private readonly IHobby _ihobby;

    public HobbyApplication(IHobby ihobby)
    {
        _ihobby = ihobby;
    }

     public IReadOnlyList<Hobby> GetAll()
    {
        return _ihobby.GetAll();
    }
    

    public Hobby GetById(int id)
    {
        return _ihobby.GetById(id);
    }

    public string Add(Hobby hobby)
    {
        return _ihobby.Add(hobby);
    }
    public string Delete(int id)
    {
        var hobby = GetById(id);
        return _ihobby.Delete(hobby);
    }

    public Hobby Update(Hobby hobby, int id)
    {

        var HobbyTo = GetById(id);
        HobbyTo.code = hobby.code;
        HobbyTo.remark = hobby.remark;
        return _ihobby.Update(HobbyTo);
    }
}