using asp.Data;
using asp.Model;
using asp.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryControllers : ControllerBase
{
    // private readonly AspContext _aspContext;

    // public CountryControllers(AspContext aspContext)
    // {
    //         _aspContext=aspContext;
    // }


    // [HttpGet]
    // public List<Country> GetCountries()
    // {
    //     return _aspContext.Countries.Include(y=>y.CapitalCity).ToList();
    // }

    // [HttpPost]
    // public string AddCountries(Country country)
    // {
    //     _aspContext.Countries.Add(country);
    //     _aspContext.SaveChanges();
    //     return "ok";
    // }

    // [HttpGet("{id}")]

    // public Country GetCountry(int id)
    // {
    //     return _aspContext.Countries.SingleOrDefault(country=>country.Id==id);
    // }

    // [HttpDelete("{id}")]
    // public string DeleteCountry(int id)
    // {
    //     Country country=GetCountry(id);
    //     _aspContext.Countries.Remove(country);
    //     _aspContext.SaveChanges();
    //     return "Deleted";

    // }

    // [HttpPut("{id}")]
    //  public string UpdateCountry(Country country,int id)
    //  {
    //    Country country1=GetCountry(id);
    //     if(country1 != null)
    //          {
    //              country1.Name = country.Name;
    //              country1.Population = country.Population;
    //              country1.continent = country.continent;
    //               _aspContext.SaveChanges();
    //                return "Updated";
    //       }
    //       else
    //       return "notUpdate";
       
       
    // }

    private readonly ICountry _iCountry;
    public CountryControllers(ICountry iCountry)
    {
        _iCountry=iCountry;
    }

    [HttpGet]
    public List<Country> GetCountries()
    {
        return _iCountry.GetAll().ToList();
    }

    [HttpGet("{id}")]
    public Country GetCountry(int id)
    {
        return _iCountry.GetById(id);
    }

    [HttpDelete("{id}")]
    public string DeleteCountry(int id)
    {
        return _iCountry.Delete(id);
    }

    [HttpPost]
    public string AddCountries(Country country)
    {
        return _iCountry.Add(country);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult>Update(Country country,int id)
    {
       await _iCountry.Update(country,id);
        return NoContent();
    }
}