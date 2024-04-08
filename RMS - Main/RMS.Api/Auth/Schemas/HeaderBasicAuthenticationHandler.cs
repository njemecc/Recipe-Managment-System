using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using RMS.Api.Auth.Options;
using RMS.Application.Common.Interfaces;

namespace RMS.Api.Auth.Schemas;

public class HeaderBasicAuthenticationHandler : AuthenticationHandler<HeaderBasicAuthenticationSchemeOptions>
{

    private readonly IPostgresDbContext _dbContext;
    
    
    [Obsolete("Obsolete")]
    public HeaderBasicAuthenticationHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options,ILoggerFactory logger, UrlEncoder encoder,IPostgresDbContext dbContext,ISystemClock clock): base(options, logger, encoder, clock)
    {
        _dbContext = dbContext;
    }

    public HeaderBasicAuthenticationHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options,
        ILoggerFactory logger, UrlEncoder encoder, IPostgresDbContext dbContext) : base(options, logger, encoder)
    {
        _dbContext = dbContext;
    }


    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {

            var username = Request.Headers[Options.UsernameHeader].FirstOrDefault() ??
                           throw new InvalidOperationException("Missing username header");
            
            var password = Request.Headers[Options.PasswordHeader]
                               .FirstOrDefault() ??
                           throw new InvalidOperationException("Missing Password header");

            var user = Options.Users.SingleOrDefault(user =>
                           user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                           user.Password.Equals(password, StringComparison.OrdinalIgnoreCase)) ??
                       throw new InvalidOperationException("User not found");
            
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,
                    username)
            };
            
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role,
                role)));
            claims.AddRange(user.Claims.Select(x => new Claim(x.Key,
                x.Value)));

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims,
                "Tokens"));
            var ticket = new AuthenticationTicket(principal,
                Scheme.Name);

            return AuthenticateResult.Success(ticket);

        }
        catch (Exception e)
        {
            return AuthenticateResult.Fail("Unauthorized");
        }
            
    }


  
}