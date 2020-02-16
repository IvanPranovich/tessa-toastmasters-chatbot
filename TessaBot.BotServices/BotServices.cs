using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using TessaBot.BotServices.Configuration;

namespace TessaBot.BotServices
{
    public class BotServices : IBotServices
    {
        public BotServices(IBotServicesConfiguration configuration, IBotTelemetryClient telemetryClient)
        {
            var qnaMakerConfiguration = configuration.GetQnaMakerConfiguration();
            QnaMakerService = new QnAMaker(new QnAMakerEndpoint
           {
               KnowledgeBaseId = qnaMakerConfiguration.KnowledgeBaseId,
               EndpointKey = qnaMakerConfiguration.ApiKey,
               Host = GetHostname(qnaMakerConfiguration.EndPoint),
           }, null, null, telemetryClient);
        }
        
        public QnAMaker QnaMakerService { get; }
        
        private static string GetHostname(string hostname)
        {
            if (!hostname.StartsWith("https://"))
            {
                hostname = string.Concat("https://", hostname);
            }

            if (!hostname.EndsWith("/qnamaker"))
            {
                hostname = string.Concat(hostname, "/qnamaker");
            }

            return hostname;
        }
    }
}