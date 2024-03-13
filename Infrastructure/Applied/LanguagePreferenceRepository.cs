namespace asp.Infrastructure.Applied;

using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class LanguagePreferenceRepository : BaseRepository<LanguagePreference>, ILanguage
{
    private readonly AspContext _aspContext;

    public LanguagePreferenceRepository(AspContext aspConteext) : base(aspConteext)
    {
        _aspContext = aspConteext;
    }

    public IEnumerable<LanguagePreference> GetByProficiency(string desiredProficiency)
    {
        return _aspContext.LanguagePreferences
            .Include(lp => lp.Language)
            .Where(lp => lp.Proficiency.Level == desiredProficiency)
            .ToList();
    }
    

    /*public override IReadOnlyList<LanguagePreference> GetAll()
    {
        return _aspContext.LanguagePreferences
        .Include(y => y.Person)
        .Include(Z => Z.Language)
        .Include(X=>X.proficiency)
        .ToList();
        
    }*/

}