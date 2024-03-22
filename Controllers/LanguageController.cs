using asp.Application.Interface;

using asp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;

[ApiController]
[Route("api/controller")]
[Authorize]

public class LanguageController : ControllerBase

{

private readonly ILanguageinterface _ilanguage;
public LanguageController(ILanguageinterface language)
{
    _ilanguage = language;
}

[HttpGet]
public List<Language> GetAll()
{
    return _ilanguage.Getall().ToList();
}

[HttpPost]
public string AddLanguage(Language language)
{
    return _ilanguage.Add(language);
}

[HttpGet("{id}")]
public Language getbyid(int id)
{
    return _ilanguage.GetById(id);
}

[HttpDelete("{id}")]
public string Delete(int id)
{
    return _ilanguage.Delete(id);
}
}