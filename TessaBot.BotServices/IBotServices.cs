using Microsoft.Bot.Builder.AI.QnA;

namespace TessaBot.BotServices
{
    public interface IBotServices
    {
        QnAMaker QnaMakerService { get; }
    }
}