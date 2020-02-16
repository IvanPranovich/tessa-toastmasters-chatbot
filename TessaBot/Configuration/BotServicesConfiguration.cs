using Microsoft.Extensions.Configuration;
using TessaBot.BotServices;
using TessaBot.BotServices.Configuration;

namespace TessaBot.Configuration
{
    /// <summary>
    /// Binding appsettings with bot services configuration.
    /// </summary>
    public class BotServicesConfiguration : IBotServicesConfiguration
    {
        private readonly IConfiguration _configuration;

        public BotServicesConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public QnaMakerConfiguration GetQnaMakerConfiguration()
        {
            return new QnaMakerConfiguration
            {
                EndPoint = GetConfigurationParameter(ConfigurationConstants.QnaMakerSection, ConfigurationConstants.QnaMakerEndpoint),
                ApiKey = GetConfigurationParameter(ConfigurationConstants.QnaMakerSection, ConfigurationConstants.QnaMakerApiKey),
                KnowledgeBaseId = GetConfigurationParameter(ConfigurationConstants.QnaMakerSection, ConfigurationConstants.QnaMakerKnowledgeBaseId),
            };
        }

        private string GetConfigurationParameter(string section, string parameter)
        {
            var configSection = _configuration.GetSection(section)
                          ?? throw new ConfigurationException(section);
            return configSection.GetSection(parameter)?.Value
                   ?? throw new ConfigurationException($"{section}:{parameter}");
        }
    }
}