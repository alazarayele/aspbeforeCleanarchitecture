using asp.Data;
using asp.Model;
using asp.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using asp.Authenticaion;

namespace asp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    // private readonly AspContext _aspContext;

    // public ProjectController(AspContext aspContext)
    // {
    //         _aspContext=aspContext;
    // }


    // [HttpGet]
    // public List<Project> GetCountries()
    // {
    //     return _aspContext.Projects.ToList();
    // }

    // [HttpPost]
    // public string AddProjects(Project project)
    // {
    //     _aspContext.Projects.Add(project);
    //     _aspContext.SaveChanges();
    //     return "ok";
    // }

    // [HttpGet("{id}")]

    // public Project GetProject(int id)
    // {
    //     return _aspContext.Projects.SingleOrDefault(project=>project.Id==id);
    // }

    // [HttpDelete("{id}")]
    // public string DeleteProject(int id)
    // {
    //     Project project=GetProject(id);
    //     _aspContext.Projects.Remove(project);
    //     _aspContext.SaveChanges();
    //     return "Deleted";

    // }


    // [HttpPut("{id}")]
    //  public string UpdateProject(Project project,int id)
    //  {
    //    Project project1=GetProject(id);
    //     if(project1 != null)
    //          {
    //              project1.Name = project.Name;
    //              project1.Station = project.Station;
               
    //               _aspContext.SaveChanges();
    //                return "Updated";
    //       }
    //       else
    //       return "notUpdate";
       
       
    // }
    private readonly IProject _iProject;

    public ProjectController(IProject iProject)
    {
        _iProject=iProject;
    }
     
     [HttpGet]
    public List<Project> GetCountries()
    {
        return _iProject.GetAll().ToList();
    }

    [HttpPost]

    public string AddProjects(Project project)
    {
        return _iProject.Add(project);
    }

    [HttpGet("{id}")]

    public ActionResult<Project> GetProject(int id)
    {
        return _iProject.GetById(id);
    }

    [HttpDelete("{id}")]
    public string DeleteProject(int id)
    {
        
       return _iProject.Delete(id);
    }

    [HttpPut("{id}")]
    public async Task Update (Project project,int id)
    {
       await _iProject.Update(project,id);

    }
}