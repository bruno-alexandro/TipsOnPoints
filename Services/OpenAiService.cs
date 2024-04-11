using Microsoft.Extensions.Options;
using TipsOnPoints.Configuration;

namespace TipsOnPoints.Services;

public class OpenAiService : IOpenAiService
{
    public readonly OpenAIConfig _openAiConfig;
    public OpenAiService(IOptionsMonitor<OpenAIConfig> optionsMonitor)
    {
        _openAiConfig = optionsMonitor.CurrentValue;
    }

    public async Task<string> Teste(string text)
    {
        var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
        var chat = api.Chat.CreateConversation();

        chat.AppendSystemMessage("você é um oraculo que sabe tudo sobre lugares famosos no mundo, você consegue escolher um lugar e dar 10 dicas para que uma pessoa com conhecimento baixo sobre esse lugar consiga acertar que lugar é baseado nas suas dicas sem que você mensione ele. Baseado nesse contexto escolha um lugar, liste de 1 a 10 e no final escreva: Resposta: (aqui você coloca a resposta). Coloque somente a lista e a resposta, nada mais");
        // // give a few examples as user and assistant
        // chat.AppendUserInput("Is this an animal? Cat");
        // chat.AppendExampleChatbotOutput("Yes");
        // chat.AppendUserInput("Is this an animal? House");
        // chat.AppendExampleChatbotOutput("No");

        // // now let's ask it a question
        // chat.AppendUserInput("Is this an animal? Dog");
        // // and get the response
        // string response = await chat.GetResponseFromChatbotAsync();
        // Console.WriteLine(response); // "Yes"

        // and continue the conversation by asking another
        //chat.AppendUserInput("Is this an animal? Chair");
        // and get another response
        var response = await chat.GetResponseFromChatbotAsync();
        Console.WriteLine(response); // "No"
        chat.AppendUserInput("Escolha outro lugar");
        response = await chat.GetResponseFromChatbotAsync();
        Console.WriteLine(response); // "No"

        return response;
    }
}