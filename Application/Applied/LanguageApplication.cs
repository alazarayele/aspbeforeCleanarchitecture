using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Model;


namespace asp.Application.Applied;


public class LanguageApplication : ILanguageinterface
{
    private readonly Ilanguages _languages;
    public LanguageApplication(Ilanguages ilanguages)
    {
        _languages = ilanguages;
    }
    public string Add(Language language)
    {
        return _languages.Add(language);
    }

    public string Delete(int id)
    {
        var languageT = GetById(id);
        return _languages.Delete(languageT);
    }

    public IReadOnlyList<Language> Getall()
    {
        return _languages.GetAll();
    }

    public Language GetById(int id)
    {
        return _languages.GetById(id);
    }

    public Language Update(Language language, int id)
    {
        throw new NotImplementedException();
    }
}