namespace asp.Infrastructure.Applied;
using asp.Model;
using asp.Infrastructure.Interface;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class CountryRepository : BaseRepository<Country>,ICountryRepository
{
    private readonly AspContext _aspContext;

    public CountryRepository(AspContext aspContext):base(aspContext)
    {
        _aspContext=aspContext;
    }

    public override IReadOnlyList<Country> GetAll()
    {
        return _aspContext.Countries.Include(y=>y.CapitalCity).ToList();
    }
}