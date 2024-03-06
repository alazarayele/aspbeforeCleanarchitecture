namespace asp.Infrastructure.Applied;



using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;
public class InterestRepository : BaseRepository<Interest>, IInterestRepository
{
    private readonly AspContext _aspContext;

    public InterestRepository(AspContext aspContext) : base(aspContext)
    {
        _aspContext = aspContext;
    }

    public override IReadOnlyList<Interest> GetAll()
    {
        return _aspContext.Interests.ToList();
    }
}