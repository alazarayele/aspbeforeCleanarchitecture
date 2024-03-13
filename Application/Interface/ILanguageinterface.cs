using asp.Model;

namespace asp.Application.Interface;



public interface ILanguageinterface
{
    IReadOnlyList<Language> Getall();

    Language GetById(int id);
    string Add(Language language);

    string Delete(int id);

    Language Update (Language language,int id);

}