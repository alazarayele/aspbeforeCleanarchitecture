


using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace asp.Authenticaion;
public class AuthenticationFilter : IActionFilter

{
    private readonly ILogger<AuthenticationFilter> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<IdentityUser> _userManager;


    public AuthenticationFilter(IHttpContextAccessor httpContextAccessor,UserManager<IdentityUser> userManager,ILogger<AuthenticationFilter> logger)
    {
         _httpContextAccessor = httpContextAccessor;
         _userManager = userManager;
         _logger = logger;
    }

      public void OnActionExecuting(ActionExecutingContext context)
        {
            // Perform authentication logic here
            // For example, check if the user is authenticated
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                _logger.LogError("Unauthorized access attempt.");
                context.Result = new UnauthorizedResult();
                return;
            }

            // If authentication is successful, do nothing and let the action execute
        }
    public async void OnActionExecuted(ActionExecutedContext context)
    {

        var userId = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        if(userId == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var user = await _userManager.FindByIdAsync(userId);
        if(user == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
       
    }

  
}