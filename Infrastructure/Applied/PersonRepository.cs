namespace asp.Infrastructure.Applied;

using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class PersonRepository : BaseRepository<Person>, IPerson
{
    private readonly AspContext _aspContext;

    public PersonRepository(AspContext aspConteext) : base(aspConteext)
    {
        _aspContext = aspConteext;
    }

    public override IReadOnlyList<Person> GetAll()
    {
        return _aspContext.Persons
        .Include(y => y.LanguagePreferences)
        .Include(Z => Z.Careers)
        .Include(X => X.Attachments)
        .Include(S => S.CommunicationSources)
        .Include(U => U.Hobbies)
        .ToList();
    }

}