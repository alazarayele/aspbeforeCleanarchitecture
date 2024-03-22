using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using asp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace asp.Controllers;



   

public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;


    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("api/register")]
    public async Task<IActionResult> Register(Registeration registeration)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = registeration.Email, Email = registeration.Email };
            var result = await _userManager.CreateAsync(user, registeration.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok("Registration successful");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return BadRequest(ModelState);
    }

    [HttpPost]
    [Route("api/login")]
    public async Task<IActionResult> Login(Login login)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var token = Generate(login);
                return Ok(token );
            }
            if (result.IsLockedOut)
            {
                  return Unauthorized("Your account is locked out.");
            }
           if (result.RequiresTwoFactor)
            {
                  return Unauthorized("Two-factor authentication is required for this account.");
            }
           if (result.IsNotAllowed)
            {
                return Unauthorized("You are not allowed to sign in. Please verify your email.");
            }
           if (result.IsNotAllowed)
            {
              return Unauthorized("User is not allowed to sign in.");
            }
          return Unauthorized("Invalid login attempt");
        }
        return BadRequest(ModelState);
    }

    private string Generate(Login login)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials  = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

        var Claims = new[]
        {
             new Claim(ClaimTypes.Email,login.Email)
             
        };
        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
        _configuration["Jwt:Audience"],
        Claims,
        expires:DateTime.Now.AddMinutes(15),
        signingCredentials : credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}