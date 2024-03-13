using asp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace asp.Controllers;



   

public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;


    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
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
                return Ok("Login successful");
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
}