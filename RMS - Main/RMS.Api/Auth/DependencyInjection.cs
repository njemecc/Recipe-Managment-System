using RMS.Api.Auth.Constants;
using RMS.Api.Auth.Options;
using RMS.Api.Auth.Schemas;

namespace RMS.Api.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddBasicAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<HeaderBasicAuthenticationSchemeOptions, HeaderBasicAuthenticationHandler>(
                AuthConstants.HeaderBasicAuthenticationScheme,
                schemeOptions => configuration.GetSection("Auth:Header").Bind(schemeOptions));

        return services;
    }
}