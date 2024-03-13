namespace asp.Application.Interface;
using asp.Model;

public interface ILanguagePreference

{
    IReadOnlyList<LanguagePreference> GetAll(int id);
    
    IEnumerable<LanguagePreference> GetByProficiency(string desiredProficiency);
    LanguagePreference GetById(int id);

    string Add(LanguagePreference languagePreference);

    string Delete(int id);

    LanguagePreference Update(LanguagePreference languagePreference,int id);
}