using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.AI.QnA.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using TessaBot.Dialogs.Conversations.Faq;

namespace TessaBot.Dialogs.Conversations
{
    public class RootDialog : ComponentDialog
    {
        private enum DialogNames
        {
            Initial,
        }
        
        public RootDialog(FaqDialog faqDialog)
            : base("root")
        {
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