using asp.Application.Interface;
using asp.Authenticaion;
using asp.Model;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;


[ApiController]
[Route("api/[controller]")]

public class Languageproficency : ControllerBase
{
     private readonly ILanguagePreference _ilanguagePreference;
public Languageproficency(ILanguagePreference languagePreference)
{

    _ilanguagePreference = languagePreference;
}

[HttpGet]


public List<LanguagePreference> getall(int desiredProficiency)
{
    return _ilanguagePreference.GetAll(desiredProficiency).ToList();
}

[HttpPost]
public string AddLanguagePreference(LanguagePreference languagePreference)
{
    return _ilanguagePreference.Add(languagePreference);
}

[HttpGet("{id}")]
public LanguagePreference GetBYId(int id)
{
    return _ilanguagePreference.GetById(id);
}
[HttpDelete("{id}")]
public string DeleteLanguagePreference(int id)
{
    return _ilanguagePreference.Delete(id);
}
}