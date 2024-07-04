using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Extensions.Logging;

namespace Services.Adapters;
public class AdapterWithErrorHandler : BotFrameworkHttpAdapter
{
    public AdapterWithErrorHandler(ILogger<BotFrameworkHttpAdapter> logger)
    {
        OnTurnError = async (turnContext, exception) =>
        {
            logger.LogError($"Exception caught : {exception.Message}");
            await turnContext.SendActivityAsync("Sorry, it looks like something went wrong.");
            await turnContext.TraceActivityAsync("OnTurnError Trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError");
        };
    }
}