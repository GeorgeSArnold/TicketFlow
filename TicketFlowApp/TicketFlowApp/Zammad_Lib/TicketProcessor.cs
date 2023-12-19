using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zammad_Lib.Models;
using Newtonsoft.Json;

namespace Zammad_Lib
{
    public class TicketProcessor
    {
        private static TicketProcessor _instance;
        public static TicketProcessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TicketProcessor();
                }
                return _instance;
            }
        }

        // ticket > id
        public async Task<TicketModel> LoadTicket(int ticketId, string apiUrl, string apiToken)
        {
            if (ticketId <= 0)
                throw new ArgumentException("Invalid ticket ID. Ticket ID must be greater than 0.");

            string url = $"{apiUrl}/api/v1/tickets/{ticketId}?expand=true";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        TicketModel ticket = await response.Content.ReadAsAsync<TicketModel>();
                        await Console.Out.WriteLineAsync("####### Ticket loaded ########");
                        return ticket;
                    }
                    else
                    {
                        throw new Exception($"Failed to load ticket. Status code: {response.StatusCode}");
                    }
                }
            }
        }

        //// ticket > list > datagrid
        //public async Task<List<TicketModel>> LoadTickets(string apiUrl, string apiToken)
        //{
        //    // load expand view ->
        //    //string url = $"{apiUrl}/api/v1/tickets?expand=true";

        //    string url = $"{apiUrl}/api/v1/tickets?expand=true&order_by_id=desc&page=8&per_page=100";


        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

        //        using (HttpResponseMessage response = await client.GetAsync(url))
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var ticketsJson = await response.Content.ReadAsStringAsync();
        //                List<TicketModel> tickets = JsonConvert.DeserializeObject<List<TicketModel>>(ticketsJson);
        //                return tickets;
        //            }
        //            else
        //            {
        //                throw new Exception($"Failed to load tickets. Status code: {response.StatusCode}");
        //            }
        //        }
        //    }
        //}

        // article
        // load article > id
        public async Task<List<ArticleModel>> LoadArticles(int ticketId, string apiUrl, string apiToken)
        {
            string url = $"{apiUrl}/api/v1/ticket_articles/by_ticket/{ticketId}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ticketsJson = await response.Content.ReadAsStringAsync();
                        List<ArticleModel> articles = JsonConvert.DeserializeObject<List<ArticleModel>>(ticketsJson);
                        return articles;
                    }
                    else
                    {
                        throw new Exception($"Failed to load articles. Status code: {response.StatusCode}");
                    }
                }
            }
        }

        // Post Response > article > server
        public async Task PostArticleToApi(ArticlePostModel articlePostModel, string apiUrl, string apiToken)
        {
            try
            {
                string url = $"{apiUrl}/api/v1/ticket_articles";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                    var jsonContent = JsonConvert.SerializeObject(articlePostModel);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await client.PostAsync(url, content))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception($"Failed to post article. Status code: {response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error posting article: " + ex.Message);
            }
        }


        //___________________________________________________________________________________________________________________________________
        //TODO: ticketslist > 100 per page 

        // ticket > list > datagrid
        public async Task<List<TicketModel>> LoadTickets(string apiUrl, string apiToken)
        {
            // fields
            const int itemsPerPage = 100;
            int currentPage = 1;
            List<TicketModel> allTickets = new List<TicketModel>();

            // check

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                
                bool morePagesAvailable = true;
                
                while(morePagesAvailable)
                {
                    string url = $"{apiUrl}/api/v1/tickets?expand=true&order_by_id=desc&page={currentPage}&per_page={itemsPerPage}";

                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var ticketsJson = await response.Content.ReadAsStringAsync();
                            List<TicketModel> tickets = JsonConvert.DeserializeObject<List<TicketModel>>(ticketsJson);

                            if (tickets.Count > 0)
                            {
                                allTickets.AddRange(tickets);
                                currentPage++;
                            }
                            else
                            {
                                morePagesAvailable = false;
                            }
                        }
                        else
                        {
                            throw new Exception($"-> Failed to load Tickets. Status code: {response.StatusCode}");
                        }
                    }
                }
                return allTickets; 
            }
        }

        //TODO: Tickets > Paging


    }
}
