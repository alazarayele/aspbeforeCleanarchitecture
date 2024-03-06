namespace asp.Application.Interface;
using asp.Model;

public interface ILanguagePreference

{
    IReadOnlyList<LanguagePreference> GetAll();

    LanguagePreference GetById(int id);

    string Add(LanguagePreference languagePreference);

    string Delete(int id);

    LanguagePreference Update(LanguagePreference languagePreference,int id);
}