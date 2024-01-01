namespace asp.Infrastructure.Applied;

using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class CarrierRepository : BaseRepository<Career>, ICareer
{
    private readonly AspContext _aspContext;

    public CarrierRepository(AspContext aspConteext) : base(aspConteext)
    {
        _aspContext = aspConteext;
    }

    public override IReadOnlyList<Career> GetAll()
    {
        return _aspContext.Careers
        .Include(y => y.Person)
        .Include(Z => Z.Attachments)
        .ToList();
    }

}