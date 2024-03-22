using Microsoft.AspNetCore.Mvc;
using asp.Application.Interface;
using asp.Model;
using Microsoft.AspNetCore.Authorization;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PersonController : ControllerBase
{
    private readonly IPersons _persons;

    public PersonController(IPersons persons)
    {
        _persons = persons;
    }

    [HttpGet]
    public List<Person> Getall()
    {
        return _persons.GetAll().ToList();
    }

    [HttpPost]
    public string AddPerson(Person person)
    {
        return _persons.Add(person);
    }

    [HttpGet("id")]
    public Person GetPerson(int id)
    {
        return _persons.GetById(id);
    }

    [HttpDelete("{id}")]
    public string DeletePerson(int id)
    {
        return _persons.Delete(id);
    }
}
