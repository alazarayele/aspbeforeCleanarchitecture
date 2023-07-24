namespace asp.Infrastructure.Applied;

using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class CityRepository : BaseRepository<CapitalCity>,ICity
{
    private readonly AspContext _aspContext;

    public CityRepository(AspContext aspConteext) : base(aspConteext)
    {
        _aspContext=aspConteext;
    }

    public override IReadOnlyList<CapitalCity> GetAll()
    {
        return _aspContext.CapitalCities.Include(y=>y.Country).ToList();
    }

}