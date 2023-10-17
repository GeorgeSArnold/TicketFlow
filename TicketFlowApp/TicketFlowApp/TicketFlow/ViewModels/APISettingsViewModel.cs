using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using TicketFlow.Utilitys;

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

        // connection instance
        private ConnectionManager connectionManager;

        // const
        public APISettingsViewModel()
        {
            connectionManager = new ConnectionManager();
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

        #region checkmessages ip, tokens
        // fields > checkmessages
        private string checkMessageServer;
        public string CheckMessageServer
        {
            get { return checkMessageServer; }
            set
            {
                checkMessageServer = value;
                NotifyOfPropertyChange(() => CheckMessageServer);
            }
        }
        private string checkMessageZammad;
        public string CheckMessageZammad
        {
            get { return checkMessageZammad; }
            set
            {
                checkMessageZammad = value;
                NotifyOfPropertyChange(() => CheckMessageZammad);
            }
        }
        private string checkMessageGPT;
        public string CheckMessageGPT
        {
            get { return checkMessageGPT; }
            set
            {
                checkMessageGPT = value;
                NotifyOfPropertyChange(() => CheckMessageGPT);
            }
        }
        #endregion

        #region checkmessages
        // check bools
        private bool isServerIpValidAndSaved;
        public bool IsServerIpValidAndSaved
        {
            get { return isServerIpValidAndSaved; }
            set
            {
                isServerIpValidAndSaved = value;
                NotifyOfPropertyChange(() => IsServerIpValidAndSaved);
            }
        }
        private bool isZammadTokenValidAndSaved;
        public bool IsZammadTokenValidAndSaved
        {
            get { return isZammadTokenValidAndSaved; }
            set
            {
                isZammadTokenValidAndSaved = value;
                NotifyOfPropertyChange(() => IsZammadTokenValidAndSaved);
            }
        }
        private bool isGptTokenValidAndSaved;
        public bool IsGptTokenValidAndSaved
        {
            get { return isGptTokenValidAndSaved; }
            set
            {
                isGptTokenValidAndSaved = value;
                NotifyOfPropertyChange(() => IsGptTokenValidAndSaved);
            }
        }
        #endregion

        // methods save & check btns > UI
        public void SaveConnectionDetails()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ServerIp) && string.IsNullOrWhiteSpace(ZammadToken) && string.IsNullOrWhiteSpace(GptToken))
                {
                    MessageBox.Show("Please fill in at least one connection detail.");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(ServerIp))
                    connectionManager.ServerIp = ServerIp;

                if (!string.IsNullOrWhiteSpace(ZammadToken))
                    connectionManager.ZammadToken = ZammadToken;

                if (!string.IsNullOrWhiteSpace(GptToken))
                    connectionManager.GptToken = GptToken;

                connectionManager.SaveConnectionDetails();

                if (!string.IsNullOrWhiteSpace(connectionManager.ServerIp))
                    CheckMessageServer = "Server IP valid and saved";

                if (!string.IsNullOrWhiteSpace(connectionManager.ZammadToken))
                    CheckMessageZammad = "Zammad Token valid and saved";

                if (!string.IsNullOrWhiteSpace(connectionManager.GptToken))
                    CheckMessageGPT = "ChatGPT Token valid and saved";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving connection details: " + ex.Message);
            }
        }
        public void LoadConnectionDetails()
        {
            LoadedServerIp = connectionManager.ServerIp;
            LoadedZammadToken = connectionManager.ZammadToken;
            LoadedGptToken = connectionManager.GptToken;

            if (string.IsNullOrWhiteSpace(LoadedServerIp))
                CheckMessageServer = "Server IP not found";
            else
                CheckMessageServer = "Server IP valid and saved";

            if (string.IsNullOrWhiteSpace(LoadedZammadToken))
                CheckMessageZammad = "Zammad Token not found";
            else
                CheckMessageZammad = "Zammad Token valid and saved";

            if (string.IsNullOrWhiteSpace(LoadedGptToken))
                CheckMessageGPT = "ChatGPT Token not found";
            else
                CheckMessageGPT = "ChatGPT Token valid and saved";
        }
    }
}
