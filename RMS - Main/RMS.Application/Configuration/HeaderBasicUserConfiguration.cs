using System.Runtime.InteropServices.JavaScript;

namespace RMS.Application.Configuration;

public class HeaderBasicUserConfiguration
{
    public string Username { get; init; } = null!;

    public string Password { get; init; } = null!;

    public string[] Roles { get; init; } = Array.Empty<string>();

    public Dictionary<string,string> Claims { get; init; } = new Dictionary<string, string>();
}