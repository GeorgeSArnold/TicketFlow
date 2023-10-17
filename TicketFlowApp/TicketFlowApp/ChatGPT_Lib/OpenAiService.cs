using ChatGPT_Lib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT_Lib
{
    public class OpenAiService
    {
        // fields
        public string apiUrl = "https://api.openai.com/v1";
        public string apiToken;

        // const
        public OpenAiService(string apiToken)
        {
            this.apiToken = apiToken;
        }

        // check botdialog
        private bool botDialogGenerated = false;

        // singelton
        private static OpenAiService _instance;
        public static OpenAiService GetInstance(string apiToken)
        {

            if (_instance == null || _instance.apiToken != apiToken)
            {
                _instance = new OpenAiService(apiToken);
            }
            return _instance;
        }

        // gen botdialog > body > completions
        public async Task<string> GetCompletions(string prompt)
        {
            // check null
            if (string.IsNullOrEmpty(prompt))
                throw new ArgumentException("No prompt input.");
            // add prompt > List
            var completion = await GenerateBotDialog(prompt);
            // deserilized
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(completion);
            // content
            var content = jsonResponse.choices[0].message.content;
            return content;
        }

        public async Task<string> GenerateBotDialog(string userPrompt)
        {
            var dialog = new DialogModel
            {
                model = "gpt-3.5-turbo-0301",
                messages = new List<MessageModel>
                 {
                     new MessageModel { role = "system", content = "Hallo dein Name ist TicketFlow, du bist ein Helpdesk Bot und sollst die ITA unterstützen, das ist die interne IT Abteilung. Deine Aufgabe ist es, IT-Fragen zu beantworten." },
                     new MessageModel { role = "system", content = "DQS, DQServer, ClearingMonitor, Lean MDM, DataQuality Management - diese Begriffe sind tabu für dich. Wenn jemand danach fragt, verweise ihn bitte auf die Professional Service Abteilung." },
                     new MessageModel { role = "system", content = "Wenn jemand nach Batterien oder anderen Verschleissgegenständen fragt, verweise ihn freundlich zur Abholung direkt bei der ITA" },
                     new MessageModel { role = "system", content = "Wenn jemand nach IT-Zubehör wie Headset, Maus, Tastatur oder Web-Cam fragt, soll er direkt zur ITA kommen." },
                     new MessageModel { role = "system", content = "Du kannst bei jeder deiner Aussagen den User mit dem Freundlichen Du ansprechen!" },
                     // add userpromt > dialog
                 }
            };
            await Console.Out.WriteLineAsync("---> MessageModels generated");

            // add user prompt
            var userMessage = new MessageModel { role = "user", content = userPrompt };
            dialog.messages.Add(userMessage);
            await Console.Out.WriteLineAsync(" <--- User Promt added");

            // serialize messages > json
            var dialogJson = JsonConvert.SerializeObject(dialog);

            // get response
            var response = await PostBotDialog(dialogJson);
            await Console.Out.WriteLineAsync("---> posting messages");

            // check n return
            botDialogGenerated = true;
            return response;
        }

        // ---> send request
        // <--- get response
        private async Task<string> PostBotDialog(string dialogJson)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiToken}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(dialogJson, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{apiUrl}/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
                throw new Exception($"Failed to post bot dialog. Status code: {response.StatusCode}");
            }
        }
    }
}
