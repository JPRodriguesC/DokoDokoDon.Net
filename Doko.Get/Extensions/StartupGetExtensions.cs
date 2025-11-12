using Doko.Get.Interface;
using Doko.Get.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Doko.Get.Extensions;

public static class StartupGetExtensions
{
    public static IServiceCollection AddApiClients(this IServiceCollection services)
    {
        services.AddHttpClient<IPublicMALApi, PublicMyAnimeListApi>();

        return services;
    }
}