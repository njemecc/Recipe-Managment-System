using Microsoft.Extensions.DependencyInjection;
using RMS.SDK.Application.Client;

namespace RMS.SDK.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddRmsSdk(this IServiceCollection services)
    {
        services.AddScoped<IRmsSdkClient, RmsSdkClient>();
        return services;
    }
    
}