using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Services.Bots;
public class EchoBot : ActivityHandler
{
    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var replyText = "";
        if (turnContext.Activity.Text.ToLower().Contains("israel"))
                replyText = "Olá, Israel";
        else if(turnContext.Activity.Text.ToLower().Contains("gustavo"))
            replyText = "Olá, Gustavo";
        else
            replyText = "Olá, posso ajudar em algo ?";

        await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
    }
}
