using asp.Model;
using Microsoft.EntityFrameworkCore;

namespace asp.Data;

public class AspContext : DbContext
{

    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Career> Careers { get; set; }
    public DbSet<CommunicationSource> CommunicationSources { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguagePreference> LanguagePreferences { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Proficiency> Proficiencies { get; set; }
    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<CapitalCity> CapitalCities { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    public AspContext(DbContextOptions<AspContext> dbContextOptions) : base(dbContextOptions) { }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>(x => x.HasMany(y => y.Courses).WithOne(z => z.Student).HasForeignKey(c => c.StudentId));

        modelBuilder.Entity<EmployeeProject>()
        .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

        modelBuilder.Entity<EmployeeProject>()
           .HasOne(ep => ep.Employee)
           .WithMany(e => e.EmployeeProjects)
           .HasForeignKey(ep => ep.EmployeeId);

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Project)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);


        modelBuilder.Entity<Attachment>()
        .HasOne(a => a.Person)
        .WithMany(p => p.Attachments)
        .HasForeignKey(a => a.PersonId)
        .OnDelete(DeleteBehavior.Restrict);




        // Relationship between Attachment and Career
        modelBuilder.Entity<Attachment>()
            .HasOne(a => a.Career)
            .WithMany(c => c.Attachments)
            .HasForeignKey(a => a.CareerId);

        // Relationship between Career and Person
        modelBuilder.Entity<Career>()
            .HasOne(c => c.Person)
            .WithMany(p => p.Careers)
            .HasForeignKey(c => c.personId)
            .OnDelete(DeleteBehavior.Restrict);

        // Relationship between CommunicationSource and Person
        modelBuilder.Entity<CommunicationSource>()
            .HasOne(cs => cs.Person)
            .WithMany(p => p.CommunicationSources)
            .HasForeignKey(cs => cs.PersonId);

        // Relationship between Hobby and Person
        modelBuilder.Entity<Hobby>()
            .HasOne(h => h.Person)
            .WithMany(p => p.Hobbies)
            .HasForeignKey(h => h.PersonId);

        // Relationship between Hobby and Interest
        modelBuilder.Entity<Hobby>()
            .HasOne(h => h.Interest)
            .WithMany()
            .HasForeignKey(h => h.InterestId);

        // Relationship between LanguagePreference and Person
        modelBuilder.Entity<LanguagePreference>()
            .HasOne(lp => lp.Person)
            .WithMany(p => p.LanguagePreferences)
            .HasForeignKey(lp => lp.PersonId);

        // Relationship between LanguagePreference and Language
        modelBuilder.Entity<LanguagePreference>()
            .HasOne(lp => lp.Language)
            .WithMany()
            .HasForeignKey(lp => lp.LanguageId);

        // Relationship between LanguagePreference and Proficiency
        modelBuilder.Entity<LanguagePreference>()
            .HasOne(lp => lp.Proficiency)
            .WithMany()
            .HasForeignKey(lp => lp.ProficiencyId);




    }
}