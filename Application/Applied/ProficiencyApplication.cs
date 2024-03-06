namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class ProficiencyApplication : IProficiency
{
    private readonly IProficiencyRepository _proficiency;

    public ProficiencyApplication(IProficiencyRepository proficiency)
    {
        _proficiency = proficiency;
    }

     public IReadOnlyList<Proficiency> GetAll()
    {
        return _proficiency.GetAll();
    }
    

    public Proficiency GetById(int id)
    {
        return _proficiency.GetById(id);
    }

    public string Add(Proficiency proficiency)
    {
        return _proficiency.Add(proficiency);
    }
    public string Delete(int id)
    {
        var proficiencyT = GetById(id);
        return _proficiency.Delete(proficiencyT);
    }

    public Proficiency Update(Proficiency proficiency, int id)
    {

        var proficiencyT = GetById(id);
        proficiencyT.Level = proficiency.Level;
      
        return _proficiency.Update(proficiencyT);
    }

   
}