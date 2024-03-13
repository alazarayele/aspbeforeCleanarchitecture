using Microsoft.AspNetCore.Mvc;

using asp.Application.Interface;
using asp.Model;

namespace asp.Controllers;


[ApiController]
[Route("api/[controller]")]


public class AttachementController : ControllerBase

{
    private readonly IAttachments _iattachments;

    public AttachementController(IAttachments attachments)
    {
        _iattachments = attachments;
    }

    [HttpGet]
    public List<Attachment> GetAll()
    {
        return _iattachments.GetAll().ToList();
    }

    [HttpPost]
    public string AddAttachements(Attachment attachment)
    {
        return _iattachments.Add(attachment);
    }

    [HttpGet("id")]
    public Attachment GetAttachment(int id)
    {
        return _iattachments.GetById(id);
    }

    [HttpDelete("{id}")]
    public string Deleteattachement(int id)
    {
        return _iattachments.Delete(id);
    }
}