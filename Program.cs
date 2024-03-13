using asp.Data;
using Microsoft.EntityFrameworkCore;
using asp.Infrastructure.Applied;
using asp.Infrastructure.Interface;
using asp.Application.Applied;
using asp.Application.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICity, CityRepository>();
builder.Services.AddScoped<IAttachment, AttachmentRepository>();
builder.Services.AddScoped<ICareer, CarrierRepository>();
builder.Services.AddScoped<IPerson,PersonRepository>();
builder.Services.AddScoped<IHobby,HobbyRepository>();
builder.Services.AddScoped<IInterestRepository,InterestRepository>();
builder.Services.AddScoped<ILanguage,LanguagePreferenceRepository>();
builder.Services.AddScoped<Ilanguages,LanguageRepository>();
builder.Services.AddScoped<IProficiencyRepository,ProficiencyRepository>();

builder.Services.AddScoped<IStudent, StudentApplication>();
builder.Services.AddScoped<ICourse, CourseApplication>();
builder.Services.AddScoped<IProject, ProjectApplication>();
builder.Services.AddScoped<IEmployee, EmployeeApplication>();
builder.Services.AddScoped<ICountry, CountryApplication>();
builder.Services.AddScoped<ICapitalCity, CapitalCityApplication>();
builder.Services.AddScoped<IAttachments, AttachmentApplication>();
builder.Services.AddScoped<Icarrier, CarrierApplication>();
builder.Services.AddScoped<IPersons,PersonApplication>();
builder.Services.AddScoped<IHobbies,HobbyApplication>();
builder.Services.AddScoped<IInterest,InterestApplication>();
builder.Services.AddScoped<ILanguagePreference,LanguagePreferenceApplication>();
builder.Services.AddScoped<ILanguageinterface,LanguageApplication>();
builder.Services.AddScoped<IProficiency,ProficiencyApplication>();
builder.Services.AddMvc().AddNewtonsoftJson(x =>
{
    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var conn = builder.Configuration.GetConnectionString("DataBaseConnection");
builder.Services.AddDbContext<AspContext>(dbcontext =>
{
    dbcontext.UseSqlServer(conn);
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
