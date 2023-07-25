namespace asp.Application.Applied;

using System.Collections.Generic;
using asp.Application.Interface;
using asp.Model;
using asp.Infrastructure.Interface;

public class ProjectApplication : IProject
{

    private readonly IProjectRepository _iProjectRepository;

    public ProjectApplication(IProjectRepository iProjectRepository)
    {
        _iProjectRepository=iProjectRepository;
    }
    public string Add(Project project)
    {
        return _iProjectRepository.Add(project);
    }

    public string Delete(int id)
    {
        var project=GetById(id);
        return _iProjectRepository.Delete(project);

    }

    public IReadOnlyList<Project> GetAll()
    {
       return _iProjectRepository.GetAll();
    }
    public Project GetById(int id)
    {
        return _iProjectRepository.GetById(id);
    }

    public async Task Update(Project project,int id)
    {
        var projectTo=GetById(id);

        projectTo.Name=project.Name;
        projectTo.Station=project.Station;


        _iProjectRepository.Update(projectTo);

    }
}