using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TicketFlow.Utilitys;
using Zammad_Lib;
using Zammad_Lib.Models;
using ChatGPT_Lib;
using ChatGPT_Lib.Models;


namespace TicketFlow.ViewModels
{
    /// <summary>
    /// EditView > Editing ArticleBody > ResponseBody 
    /// Get ChatGpt Promt
    /// </summary>
    public class EditViewModel : Caliburn.Micro.Screen
    {
        // props
        // input < UI
        private int ticketId;
        // ticket fields
        private int id;
        private int number;
        private string title;
        private List<int> article_ids;
        private string articleIdsString;
        // articleId > UI
        private int articleId;
        // richtxtBox
        private string body;

        // input < UI
        public int TicketId
        {
            get { return ticketId; }
            set
            {
                ticketId = value;
                NotifyOfPropertyChange(() => TicketId);
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        // const
        public EditViewModel(TicketModel ticket)
        {
            SelectedTicket = ticket;
            LoadLatestArticleBody();
        }

        // output > UI
        private List<ArticleModel> articles;
        // output < api
        public List<int> Article_ids
        {
            get { return article_ids; }
            set
            {
                article_ids = value;
                NotifyOfPropertyChange(() => Article_ids);
            }
        }
        // output > UI
        public string ArticleIdsString
        {
            get { return articleIdsString; }
            set
            {
                articleIdsString = value;
                NotifyOfPropertyChange(() => ArticleIdsString);
            }
        }
        // output < api
        public List<ArticleModel> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                NotifyOfPropertyChange(() => Articles);
            }
        }
        // input < UI
        public int CurrentArticleId
        {
            get { return articleId; }
            set
            {
                articleId = value;
                NotifyOfPropertyChange(() => CurrentArticleId);
            }
        }

        // richtxtB < body < article
        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                NotifyOfPropertyChange(() => Body);
            }
        }

        // article methods
        // article_ids > string
        private void UpdateArticleIdsString()
        {
            ArticleIdsString = string.Join(", ", Article_ids);
        }
        // update int > string
        public void UpdateArticleIds(List<int> articleIds)
        {
            Article_ids = articleIds;
            UpdateArticleIdsString();
        }

        // selected ticket obj
        private TicketModel selectedTicket;
        public TicketModel SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);

                if (selectedTicket != null)
                {
                    TicketId = selectedTicket.Id;
                    Console.WriteLine("---> selected Ticket ID: " + TicketId);
                }
            }
        }

        // article logic
        public async Task LoadLatestArticleBody()
        {
            try
            {
                List<ArticleModel> articles = await LoadAllArticlesFromTicket(TicketId);

                if (articles != null)
                {
                    Articles = new List<ArticleModel>(articles);
                    ArticleModel latestArticle = GetLatestArticle(articles);
                    LastArticleBody = CleanBodyFromTags(latestArticle);

                    ArticleIdsString = string.Join(", ", articles.Select(a => a.Id));

                    Article_ids = articles.Select(a => a.Id).ToList();

                    if (articles.Count > 0)
                    {
                        CurrentArticleId = articles.OrderByDescending(a => a.Id).First().Id;
                        Console.WriteLine($"Latest Article Id: {CurrentArticleId}");
                    }

                    CurrentArticleId = latestArticle.Id;
                    await Console.Out.WriteLineAsync($"# Body: {Body}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden des Artikel-Body: " + ex.Message);
            }
        }
        private async Task<List<ArticleModel>> LoadAllArticlesFromTicket(int ticketId)
        {
            try
            {
                TicketProcessor ticketProcessor = TicketProcessor.Instance;
                APISettingsViewModel asvm = new APISettingsViewModel();

                string serverIP = asvm.GetServerIp();
                string zammadToken = asvm.GetZammadToken();

                return await ticketProcessor.LoadArticles(ticketId, serverIP, zammadToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden der Artikel: " + ex.Message);
                return null;
            }
        }
        public ArticleModel GetLatestArticle(List<ArticleModel> articles)
        {
            if (articles == null || articles.Count == 0)
            {
                return null;
            }
            return articles.OrderByDescending(a => a.Id).First();
        }
        // clean
        public string CleanBodyFromTags(ArticleModel latestArticle)
        {
            if (latestArticle == null)
            {
                return null;
            }
            string cleanedBody = RemoveHtmlTags(latestArticle.Body);

            return cleanedBody;
        }
        // remove tags
        private string RemoveHtmlTags(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        // relay fields > buttons > UI
        private ICommand getsuggestCommand;
        public ICommand GetSuggestCommand
        {
            get
            {
                if (getsuggestCommand == null)
                    getsuggestCommand = new RelayCommand(param => GetSuggest(LastArticleBody));
                return getsuggestCommand;
            }
        }
        // input <--- article body 
        private string lastArticleBody;
        public string LastArticleBody 
        {
            get { return lastArticleBody; }
            set
            {
                lastArticleBody = value;
                NotifyOfPropertyChange(() => LastArticleBody);
            }
        }
        // output ---> responseBody  
        private string responseBody;
        public string ResponseBody
        {
            get { return responseBody; }
            set
            {
                responseBody = value;
                NotifyOfPropertyChange(() => ResponseBody);
            }
        }
        // update article > zammad
        private ICommand updateArticleCommand;
        public ICommand PostResponseAsArticleCommand
        {
            get
            {
                if (updateArticleCommand == null)
                    updateArticleCommand = new RelayCommand(param => PostResponseAsArticle());
                return updateArticleCommand;
            }
        }

        // methods btns > UI > api
        public async Task GetSuggest(string LastArticleBody)
        {
            await Console.Out.WriteLineAsync("---> send btn clicked <---");
            try
            {
                APISettingsViewModel asvm = new APISettingsViewModel();
                string apiToken = asvm.GetGptToken();
                OpenAiService openAiService = OpenAiService.GetInstance(apiToken);

                await Console.Out.WriteLineAsync("---> sending prompt --->");
                string completion = await openAiService.GetCompletions(LastArticleBody);
                await Console.Out.WriteLineAsync("<--- get completion <---");

                Console.WriteLine("Response: " + completion);

                await Console.Out.WriteLineAsync("-> complation Complete \n<- Response Complete <-");
                ResponseBody = completion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // post > responsebody > server
        public async Task PostResponseAsArticle()
        {
            Console.WriteLine("---> update article clicked <---");

            try
            {
                TicketProcessor ticketProcessor = TicketProcessor.Instance;
                APISettingsViewModel asvm = new APISettingsViewModel();
                string apiToken = asvm.GetZammadToken();
                string apiUrl = asvm.GetServerIp();

                ArticlePostModel articlePostModel = new ArticlePostModel
                {
                    ticket_id = TicketId,
                    body = ResponseBody
                };

                await ticketProcessor.PostArticleToApi(articlePostModel, apiUrl, apiToken);
                await Console.Out.WriteLineAsync("---> post response as article > server");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
