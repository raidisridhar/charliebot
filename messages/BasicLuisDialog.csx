using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I am sorry I could not understand  your question can you ask again sritest"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("Greeting")]
    public async Task GreetingIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hello how can I help you"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("Help")]
    public async Task HelpIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I am sorry to know you have a problem, I will be glad to help you"); //
        context.Wait(MessageReceived);
    }
}