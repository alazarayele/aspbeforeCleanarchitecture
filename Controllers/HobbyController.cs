using asp.Application.Interface;

using asp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;


 [ApiController]
 [Route("api/[controller]")]
[Authorize]

public class HobbyController : ControllerBase
{

   
    private readonly IHobbies _hobbies;
    public HobbyController(IHobbies hobbies)
    {
       _hobbies = hobbies;
    }
    
    [HttpGet]
    public List<Hobby> GetAll()
    {
        return _hobbies.GetAll().ToList();
    }

    [HttpPost]
    public string AddHobby(Hobby hobby)
    {
        return _hobbies.Add(hobby);
    }

    [HttpGet("{id}")]
    public Hobby GetById(int id)
    {
        return _hobbies.GetById(id);
    }

    [HttpDelete("{id}")]
    public string DeleteHobby(int id)
    {
       return _hobbies.Delete(id);
    }
}