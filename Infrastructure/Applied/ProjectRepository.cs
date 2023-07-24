namespace asp.Infrastructure.Applied;
using asp.Model;
using asp.Data;
using asp.Infrastructure.Interface;
public class ProjectRepository : BaseRepository<Project>,IProjectRepository
{
   
private readonly AspContext _aspContex;
   public ProjectRepository(AspContext aspContext):base(aspContext)
   {
        _aspContex=aspContext;
   }
}
