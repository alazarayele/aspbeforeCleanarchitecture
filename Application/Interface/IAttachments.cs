namespace asp.Application.Interface;
using asp.Model;

public interface IAttachments

{
    IReadOnlyList<Attachment> GetAll();

    Attachment GetById(int id);

    string Add(Attachment attachment);

  
    Task<string> CreateAttachmentWithPerson(int personId, Attachment attachment);
         

    string Delete(int id);

    Attachment Update(Attachment attachment,int id);
}