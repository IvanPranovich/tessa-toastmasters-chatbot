namespace TessaBot.Configuration
{
    /// <summary>
    /// Application configuration file constants
    /// </summary>
    public static class ConfigurationConstants
    {
        #region QnaMaker
        
        public const string QnaMakerSection = "QnaMakerService";
        public const string QnaMakerEndpoint = "EndPoint";
        public const string QnaMakerApiKey = "ApiKey";
        public const string QnaMakerKnowledgeBaseId = "KnowledgeBaseId";
        
        #endregion

        public const string StorageAccount = "StorageAccount";
        public const string StorageAccountBlobContainerName = "StorageAccountBlobContainerName";
    }
}