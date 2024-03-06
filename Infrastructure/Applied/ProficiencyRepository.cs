 namespace asp.Infrastructure.Applied;
  using asp.Model;
  using asp.Data;
  using asp.Infrastructure.Interface;
  using Microsoft.EntityFrameworkCore;
 public class ProficiencyRepository : BaseRepository<Proficiency>, IProficiencyRepository
    {
        private readonly AspContext _aspContext;

        public ProficiencyRepository(AspContext aspContext) : base(aspContext)
        {
            _aspContext = aspContext;
        }

        public override IReadOnlyList<Proficiency> GetAll()
        {
            return _aspContext.Proficiencies.ToList();
        }
    }