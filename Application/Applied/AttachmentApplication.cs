namespace asp.Application.Applied;

using asp.Model;
using asp.Application.Interface;
using asp.Infrastructure.Interface;
using asp.Infrastructure.Applied;
using System.Collections.Generic;

public class AttachmentApplication: IAttachments
{
    private readonly IAttachment _iattachemnt;

    public AttachmentApplication(IAttachment iattachemnt)
    {
        _iattachemnt=iattachemnt;
    }

    
    public string Add(Attachment attachment)
    {
        return _iattachemnt.Add(attachment);
    }


     
       public async Task<string> CreateAttachmentWithPerson(int personId, Attachment attachment)
        {
            var person = await _iattachemnt.GetPersonByIdAsync(personId);
            if (person == null)
            {
                return "Person not found.";
            }

            attachment.PersonId = personId;
            _iattachemnt.Add(attachment);
            await _iattachemnt.SaveChangesAsync();

            return "Attachment created successfully.";
        }
    public string Delete(int id)
    {
       var attachemnt = GetById(id);
       return _iattachemnt.Delete(attachemnt);
    }

    

   
    public Attachment Update(Attachment attachment, int id)
    {
        var attachemntsTo = GetById(id);
        attachemntsTo.refernce = attachment.refernce;
        attachemntsTo.description = attachment.description;
        attachemntsTo.url = attachment.url;
        attachemntsTo.index = attachment.index;
        attachemntsTo.type = attachment.type;
        attachemntsTo.remark = attachment.remark;
        return _iattachemnt.Update(attachemntsTo);


    }

    public IReadOnlyList<Attachment> GetAll()
    {
        return _iattachemnt.GetAll();
    }

    public Attachment GetById(int id)
    {
       return _iattachemnt.GetById(id);
    }

  
}