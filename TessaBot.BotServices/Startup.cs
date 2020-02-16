using Microsoft.Extensions.DependencyInjection;
using TessaBot.BotServices.Configuration;

namespace TessaBot.BotServices
{
    public static class Startup
    {
        public static IServiceCollection AddBotServices<T>(this IServiceCollection serviceCollection)
            where T : class, IBotServicesConfiguration
        {
            serviceCollection.AddSingleton<IBotServices, BotServices>();
            serviceCollection.AddSingleton<IBotServicesConfiguration, T>();

            return serviceCollection;
        }
    }
}