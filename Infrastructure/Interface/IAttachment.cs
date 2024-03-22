namespace asp.Infrastructure.Interface;
using asp.Model;

public interface IAttachment : IBaseRepository<Attachment>
{
             Task<Person> GetPersonByIdAsync(int personId);
    
             Task<int> SaveChangesAsync(); 

}