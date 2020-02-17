using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.AI.QnA.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Extensions.Logging;
using TessaBot.Dialogs.Conversations.Faq;

namespace TessaBot.Dialogs.Conversations
{
    public class RootDialog : ComponentDialog
    {
        private readonly ILogger<RootDialog> _logger;

        private enum DialogNames
        {
            Initial,
        }
        
        public RootDialog(FaqDialog faqDialog, ILogger<RootDialog> logger)
            : base("root")
        {
            _logger = logger;
            AddDialog(faqDialog);
            AddDialog(new WaterfallDialog(DialogNames.Initial.ToString(), new WaterfallStep[]
            {
                InitialStep,
            }));
            
            InitialDialogId = DialogNames.Initial.ToString();
        }

        private async Task<DialogTurnResult> InitialStep(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.BeginDialogAsync(nameof(QnAMakerDialog), null, cancellationToken);
        }
        
    }
}