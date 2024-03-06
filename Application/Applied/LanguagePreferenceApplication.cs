namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class LanguagePreferenceApplication : ILanguagePreference
{
    private readonly ILanguage _ilanguage;

    public LanguagePreferenceApplication(ILanguage ilanguage)
    {
        _ilanguage = ilanguage;
    }

      public IReadOnlyList<LanguagePreference> GetAll()
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