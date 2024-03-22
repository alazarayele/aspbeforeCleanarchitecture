using Microsoft.AspNetCore.Mvc;
using asp.Data;
using asp.Model;
using Microsoft.EntityFrameworkCore;
using asp.Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CityCountroller : ControllerBase
{
    // private readonly AspContext _aspContext;
    // public CityCountroller(AspContext aspContext)
    // {
    //     _aspContext=aspContext;
    // }

    // [HttpGet]
    // public List<CapitalCity> GetCapitalCities()
    // {
    //    // return _aspContext.CapitalCities.ToList();
    //     return _aspContext.CapitalCities.Include(y=>y.Country).ToList();
    // }

    // [HttpPost]
    // public string AddCity(CapitalCity capitalCity)
    // {
    //     _aspContext.CapitalCities.Add(capitalCity);
    //     _aspContext.SaveChanges();
    //     return "Successfully Added";

    // }
    // [HttpGet("{id}")]
    // public CapitalCity GetCapitalCity(int id)
    // {
    //     return _aspContext.CapitalCities.SingleOrDefault(city => city.Id==id);
    // }

    // [HttpDelete("{id}")]
    // public string DeleteCity(int id)
    // {
    //     CapitalCity capitalCity=GetCapitalCity(id);
    //     _aspContext.CapitalCities.Remove(capitalCity);
    //     _aspContext.SaveChanges();
    //     return "Successfully Deleted";
    // }

    // [HttpPut("{id}")]
    //  public string UpdateCity(CapitalCity capitalCity,int id)
    //  {
    //    CapitalCity capitalCity1=GetCapitalCity(id);
    //     if(capitalCity1 != null)
    //          {
    //              capitalCity1.CountryName = capitalCity.CountryName;
    //              capitalCity1.NumberOfPopulation = capitalCity.NumberOfPopulation;
    //              capitalCity1.CountryId = capitalCity.CountryId;
    //               _aspContext.SaveChanges();
    //                return "Updated";
    //       }
    //       else
    //       return "notUpdate";
       
       
    // }
    //EXample Update
    //   public async Task UpdateBookAsyncEasy(int bookId, BookModel bookModel)
    //     {
    //         var book = new Books()
    //         {
    //             Id=bookId,
    //             Title = bookModel.Title,
    //             Description = bookModel.Description,

    //         };
    //         _context.Books.Update(book);
    //         await _context.SaveChangesAsync();
    //     }


    private readonly ICapitalCity _iCapitalCity;

    public CityCountroller(ICapitalCity iCapitalCity)
    {
        _iCapitalCity=iCapitalCity;
    }

    [HttpGet]
    public List<CapitalCity> GetAll()
    {
        return _iCapitalCity.GetAll().ToList();
    }

    [HttpPost]
    public string AddCity(CapitalCity capitalCity)
    {
        return _iCapitalCity.Add(capitalCity);
    }

    [HttpGet("{id}")]
    public CapitalCity GetCapitalCity(int id)
    {
        return _iCapitalCity.GetById(id);
    }

    [HttpDelete("{id}")]
    public string DeleteCity(int id)
    {
     
        return _iCapitalCity.Delete(id);
    }
}