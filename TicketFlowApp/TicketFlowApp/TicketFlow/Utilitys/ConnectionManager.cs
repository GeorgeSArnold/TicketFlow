using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using TicketFlow.Utilitys.Models;

namespace TicketFlow.Utilitys
{
    public class ConnectionManager
    {
        private ConnectionDetailsModel connectionDetails;

        public ConnectionManager()
        {
            LoadConnectionDetails();
        }

        public void LoadConnectionDetails()
        {
            try
            {
                if (File.Exists("connection.json"))
                {
                    string json = File.ReadAllText("connection.json");
                    connectionDetails = JsonConvert.DeserializeObject<ConnectionDetailsModel>(json);
                }
                else
                {
                    connectionDetails = new ConnectionDetailsModel();
                    MessageBox.Show("No saved connection details found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading connection details: " + ex.Message);
            }
        }

        public void SaveConnectionDetails()
        {
            try
            {
                if (!string.IsNullOrEmpty(ServerIp))
                    connectionDetails.ServerIp = ServerIp;

                if (!string.IsNullOrEmpty(ZammadToken))
                    connectionDetails.ZammadToken = ZammadToken;

                if (!string.IsNullOrEmpty(GptToken))
                    connectionDetails.GptToken = GptToken;

                string json = JsonConvert.SerializeObject(connectionDetails);
                File.WriteAllText("connection.json", json);
                MessageBox.Show("Connection details saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving connection details: " + ex.Message);
            }
        }

        // Properties for accessing connection details
        public string ServerIp { get => connectionDetails.ServerIp; set => connectionDetails.ServerIp = value; }
        public string ZammadToken { get => connectionDetails.ZammadToken; set => connectionDetails.ZammadToken = value; }
        public string GptToken { get => connectionDetails.GptToken; set => connectionDetails.GptToken = value; }
    }
}
