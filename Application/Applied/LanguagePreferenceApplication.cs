namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class LanguagePreferenceApplication : ILanguagePreference
{
    private readonly Infrastructure.Interface.ILanguage _ilanguage;



    public LanguagePreferenceApplication(Infrastructure.Interface.ILanguage ilanguage)
    {
        _ilanguage = ilanguage;
    }
  

      public IEnumerable<LanguagePreference> GetByProficiency(string desiredProficiency)
        {
            return _ilanguage.GetByProficiency(desiredProficiency);
        }
      public IReadOnlyList<LanguagePreference> GetAll(int id)
    {
        return _ilanguage.GetAll();
        
    }

    

    public LanguagePreference GetById(int id)
    {
        return _ilanguage.GetById(id);
    }

    public string Add(LanguagePreference languagePreference)
    {
        return _ilanguage.Add(languagePreference);
    }
    public string Delete(int id)
    {
        var languagePreference = GetById(id);
        return _ilanguage.Delete(languagePreference);
    }

    public LanguagePreference Update(LanguagePreference languagePreference, int id)
    {
            
 
 var LanguageTo = GetById(id);
        LanguageTo.person = languagePreference.person;
        LanguageTo.LanguageId = languagePreference.LanguageId;
         LanguageTo.proficiency = languagePreference.proficiency;
        LanguageTo.remark = languagePreference.remark;
        return _ilanguage.Update(LanguageTo);
    }
}