namespace asp.Infrastructure.Applied;

using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class CommunicationSourceRepository : BaseRepository<CommunicationSource>, ICommunicationSource
{
    private readonly AspContext _aspContext;

    public CommunicationSourceRepository(AspContext aspConteext) : base(aspConteext)
    {
        _aspContext = aspConteext;
    }

    public override IReadOnlyList<CommunicationSource> GetAll()
    {
        return _aspContext.CommunicationSources
        .Include(y => y.Person)
        .ToList();
    }

}