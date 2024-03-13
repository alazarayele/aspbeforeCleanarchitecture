using asp.Application.Interface;
using asp.Authenticaion;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;


[ApiController]
[Route("api/[controller]")]

public class ProficiencyController : ControllerBase
{
    private readonly IProficiency _iproficiency;

    public ProficiencyController(IProficiency proficiency)
    {
        _iproficiency = proficiency;
    }

    [HttpGet]

    public List<Proficiency> GetAll()
    {
        return _iproficiency.GetAll().ToList();
    }


    [HttpPost]
    public string AddProficiency(Proficiency proficiency)
    {
        return _iproficiency.Add(proficiency);
    }

    [HttpGet("{id}")]
    public Proficiency GetBYId(int id)
    {
        return _iproficiency.GetById(id);
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _iproficiency.Delete(id);
    }
}