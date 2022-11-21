using Hostlify.Infraestructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hostlify.API.Filter;

public class AuthorizeAttribute : Attribute,IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // If action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        // Then skip authorization process
        if (allowAnonymous)
            return;
        
        
        // Authorization process
        //(User)context.HttpContext.Items["User"];
        var email = (User)context.HttpContext.Items["email"];
        Console.WriteLine("EMAIL: "+email);

        if (email == null)
        {
            context.Result = new JsonResult(new {message="Unathorized"}) {StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}