using asp.Application.Interface;
using asp.Authenticaion;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InterestController : ControllerBase

{

     private readonly IInterest _iinterest;
    public InterestController(IInterest interest)
    {
       _iinterest = interest;
    }

    [HttpGet]
    public List<Interest> GetAll()
    {
        return _iinterest.GetAll().ToList();
    }

    [HttpPost]
     public string AddInterest(Interest interest)
     {
        return _iinterest.Add(interest);
     }

     [HttpGet("{id}")]
     public Interest getById(int id)
     {
        return _iinterest.GetById(id);
     }

     [HttpDelete("{id}")]
     public string DeleteInterest(int id)
     {
        return _iinterest.Delete(id);
     }
}