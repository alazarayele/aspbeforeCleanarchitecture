namespace asp.Infrastructure.Applied;

using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class HobbyRepository : BaseRepository<Hobby>, IHobby
{
    private readonly AspContext _aspContext;

    public HobbyRepository(AspContext aspConteext) : base(aspConteext)
    {
        _aspContext = aspConteext;
    }

    public override IReadOnlyList<Hobby> GetAll()
    {
        return _aspContext.Hobbies
        .Include(y => y.Person)
        .Include(Z => Z.Interest)
        .ToList();
    }

}