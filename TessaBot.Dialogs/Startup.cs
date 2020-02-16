using System.Linq;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Extensions.DependencyInjection;

namespace TessaBot.Dialogs
{
    public static class Startup
    {
        public static IServiceCollection AddTessaDialogs(this IServiceCollection services)
        {
            services.AddSingleton<ConversationState>();
            services.AddSingleton<UserState>();
            services.AddSingleton<PrivateConversationState>();

            RegisterAllDialogs(services);
            
            return services;
        }

        /// <summary>
        /// Registers all dialogs in current assembly. All of them are singletons.
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterAllDialogs(IServiceCollection services)
        {
            var baseDialog = typeof(Dialog);
            var currentAssembly = typeof(Startup).Assembly;
            var dialogs = currentAssembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(baseDialog));

            foreach (var dialog in dialogs)
            {
                services.AddSingleton(dialog);
            }
        }
    }
}