using asp.Data;
using asp.Infrastructure.Interface;
using asp.Model;

namespace asp.Infrastructure.Applied;



public class LanguageRepository : BaseRepository<Language>,Ilanguages
{
    private readonly AspContext _aspContext;

    public LanguageRepository(AspContext aspContext) : base(aspContext)
    {
        _aspContext = aspContext;
    }

    public override IReadOnlyList<Language> GetAll()
    {
        return _aspContext.Languages.ToList();
    }

}