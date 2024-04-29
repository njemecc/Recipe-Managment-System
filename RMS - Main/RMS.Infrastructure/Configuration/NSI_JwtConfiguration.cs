namespace RMS.Infrastructure.Configuration;

public class NSI_JwtConfiguration
{
    public string? ValidAudience { get; set; }
    public string? ValidIssuer { get; set; }
    public string? Secret { get; set; }
    public string? Key { get; set; }
}