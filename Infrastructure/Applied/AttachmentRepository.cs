namespace asp.Infrastructure.Applied;

using asp.Infrastructure.Interface;
using asp.Model;
using asp.Data;
using Microsoft.EntityFrameworkCore;

public class AttachmentRepository : BaseRepository<Attachment>, IAttachment
{
    private readonly AspContext _aspContext;

    public AttachmentRepository(AspContext aspConteext) : base(aspConteext)
    {
        _aspContext = aspConteext;
    }

    public override IReadOnlyList<Attachment> GetAll()
    {
        return _aspContext.Attachments
        .Include(y => y.Person)
        .Include(Z => Z.Career)
        .ToList();
    }
         public async Task<Person> GetPersonByIdAsync(int personId)
        {
            return await _aspContext.Persons.FirstOrDefaultAsync(p => p.Id == personId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _aspContext.SaveChangesAsync();
        }

}