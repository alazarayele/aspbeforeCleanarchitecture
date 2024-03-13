using asp.Application.Interface;
using asp.Authenticaion;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;



[ApiController]
[Route("api/[controller]")]

public class CommunicationSourceController : ControllerBase
{
    private readonly ICommunicationSources _icommunicationSources;

    public CommunicationSourceController(ICommunicationSources communicationSources)
    {
         _icommunicationSources = communicationSources;
    }

    [HttpGet]
    public List<CommunicationSource> GetAll()
    {
        return _icommunicationSources.GetAll().ToList();
    }

    [HttpGet("{id}")]
    public CommunicationSource GetById(int id)
    {
        return _icommunicationSources.GetById(id);
    }

    [HttpDelete("{id}")]

    public string Delete(int id)
    {
        return _icommunicationSources.Delete(id);
    }

    [HttpPost]

    public string AddCommunicationSource(CommunicationSource communicationSource)
    {
        return _icommunicationSources.Add(communicationSource);
    }
}