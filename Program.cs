using asp.Data;
using Microsoft.EntityFrameworkCore;
using asp.Infrastructure.Applied;
using asp.Infrastructure.Interface;
using asp.Application.Applied;
using asp.Application.Interface;
using Microsoft.AspNetCore.Identity;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using asp.Authenticaion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;




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
builder.Services.AddScoped<ICommunicationSource, CommunicationSourceRepository>();


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
builder.Services.AddScoped<ICommunicationSources, CommunicationSourceApplication>();
builder.Services.AddMvc().AddNewtonsoftJson(x =>
{
    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var conn = builder.Configuration.GetConnectionString("DataBaseConnection");
builder.Services.AddDbContext<AspContext>(dbcontext =>
{
    dbcontext.UseSqlServer(conn);

    
});


           

IConfiguration Configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Configuration["Jwt:Issuer"],
        ValidAudience = Configuration["Jwt:Audience"],
     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
    };
});

 builder.Services.AddAuthorization();

    


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configure password requirements
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;

    // Configure lockout settings
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

    // Configure account confirmation
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<AspContext>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AuthenticationFilter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
