namespace asp.Infrastructure.Interface;
using asp.Model;

public interface ILanguage : IBaseRepository<LanguagePreference>
{

    
        IEnumerable<LanguagePreference> GetByProficiency(string desiredProficiency);
    
}