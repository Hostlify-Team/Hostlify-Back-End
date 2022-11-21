using Hostlify.Domain;

namespace Hostlify.API.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    
    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ITokenDomain tokenDomain, IUserDomain userDomain)
    {

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var email = tokenDomain.ValidateJwt(token);

        if (email != null)
        {
            context.Items["email"] = await  userDomain.GetByEmail(email);
        }
        
        await _next(context);
    }
}