
using asp.Application.Interface;

using asp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CarrierController : ControllerBase

{
    private readonly Icarrier _icarrier;

    public CarrierController(Icarrier icarrier)
    {
        _icarrier = icarrier;
    }

    [HttpGet]
    public List<Career> GetAll()
    {
        return _icarrier.GetAll().ToList();
    }
    [HttpPost]

    public string AddCarrier(Career career)
    {
         return _icarrier.Add(career);
    }

    [HttpGet("id")]
    public  Career GetCareer(int id)
    {
        return _icarrier.GetById(id);
    }

    [HttpDelete("{id}")]
    public string DeleteCarrier(int id)
    {
        return _icarrier.Delete(id);
    }

}



