using Microsoft.Extensions.Options;

namespace RMS.Api.Auth.Options;

public class JwtOptionsSetup: IConfigureOptions<JwtOptions>
{

    private const string SectionName = "Jwt";
    private IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}