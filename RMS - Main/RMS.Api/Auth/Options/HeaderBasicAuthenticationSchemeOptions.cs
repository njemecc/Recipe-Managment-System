using Microsoft.AspNetCore.Authentication;
using RMS.Application.Configuration;

namespace RMS.Api.Auth.Options;

public class HeaderBasicAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    public string UsernameHeader { get; set; } = "X-RMS-Username";

    public string PasswordHeader { get; set; } = "X-RMS-Password";

    public IEnumerable<HeaderBasicUserConfiguration> Users { get; init; } = Array.Empty<HeaderBasicUserConfiguration>();
}