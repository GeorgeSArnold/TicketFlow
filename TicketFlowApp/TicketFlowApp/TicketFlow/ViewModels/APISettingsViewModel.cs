using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caliburn.Micro;
using Newtonsoft.Json;

namespace TicketFlow.ViewModels
{
    public class APISettingsViewModel : Caliburn.Micro.Screen
    {
        /// <summary>
        /// Save Connection Details : Server IP, Zammad Token, ChatGPT Token > connection.json
        /// Check Save Status > CheckMessage > UI 
        /// </summary>
        // server ip
        public string ServerIp
        {
            get { return serverIp; }
            set
            {
                serverIp = value;
                NotifyOfPropertyChange(() => ServerIp);
            }
        }
        private string serverIp;

        // zammad
        public string ZammadToken
        {
            get { return zammadToken; }
            set
            {
                zammadToken = value;
                NotifyOfPropertyChange(() => ZammadToken);
            }
        }
        private string zammadToken;

        // gpt
        public string GptToken
        {
            get { return gptToken; }
            set
            {
                gptToken = value;
                NotifyOfPropertyChange(() => GptToken);
            }
        }
        private string gptToken;

        // loaded ip
        public string LoadedServerIp
        {
            get { return loadedServerIp; }
            set
            {
                loadedServerIp = value;
                NotifyOfPropertyChange(() => LoadedServerIp);
            }
        }
        private string loadedServerIp;

        // loaded zammad
        public string LoadedZammadToken
        {
            get { return loadedZammadToken; }
            set
            {
                loadedZammadToken = value;
                NotifyOfPropertyChange(() => LoadedZammadToken);
            }
        }
        private string loadedZammadToken;

        // loaded gpt
        public string LoadedGptToken
        {
            get { return loadedGptToken; }
            set
            {
                loadedGptToken = value;
                NotifyOfPropertyChange(() => LoadedGptToken);
            }
        }
        private string loadedGptToken;

        // const
        public APISettingsViewModel()
        {
            LoadConnectionDetails();
        }

        // get methods
        public string GetServerIp()
        {
            return LoadedServerIp;
        }
        public string GetZammadToken()
        {
            return LoadedZammadToken;
        }
        public string GetGptToken()
        {
            return loadedGptToken;
        }

        // save & load
        public void SaveConnectionDetails()
        {
            try
            {
                var connectionDetails = new
                {
                    ServerIp,
                    ZammadToken,
                    GptToken
                };

                string json = JsonConvert.SerializeObject(connectionDetails);
                File.WriteAllText("connection.json", json);
                MessageBox.Show("Connection details saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving connection details: " + ex.Message);
            }
        }
        // check saved?
        public void LoadConnectionDetails()
        {
            try
            {
                if (File.Exists("connection.json"))
                {
                    string json = File.ReadAllText("connection.json");
                    var connectionDetails = JsonConvert.DeserializeObject<dynamic>(json);

                    LoadedServerIp = connectionDetails.ServerIp;
                    LoadedZammadToken = connectionDetails.ZammadToken;
                    LoadedGptToken = connectionDetails.GptToken;
                }
                else
                {
                    MessageBox.Show("No saved connection details found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("connection.json invalid! " + ex.Message);
            }
        }
    }
}
