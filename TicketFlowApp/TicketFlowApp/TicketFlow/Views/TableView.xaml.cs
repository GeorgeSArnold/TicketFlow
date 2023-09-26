using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using TicketFlow.Models;
using System.Collections.ObjectModel;

namespace TicketFlow.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {
        public TableView()
        {
            ObservableCollection<TicketModel> tickets = new ObservableCollection<TicketModel>();
            InitializeComponent();

            var converter = new BrushConverter();

            // DUMMY TICKETS
            // create items > DataGrid
            tickets.Add(new TicketModel { Id = "1", UserId = "1", Name = "Ticket01ITA", Created = "12.03.2023:09:32", Status = "open", Article = new string[] { "Hallo IT!", "mein zweiter Monitor ist ausgefallen!" } });
            tickets.Add(new TicketModel { Id = "2", UserId = "1", Name = "Ticket02ITA", Created = "13.03.2023:11:30", Status = "open", Article = new string[] { "Hallo IT!", "meine Maus ist kaputt!" } });
            tickets.Add(new TicketModel { Id = "3", UserId = "1", Name = "Ticket03ITA", Created = "14.03.2023:14:30", Status = "closed", Article = new string[] { "Hallo IT!", "mein VPN geht nicht!" } });
            tickets.Add(new TicketModel { Id = "4", UserId = "2", Name = "Ticket04ITA", Created = "14.03.2023:16:30", Status = "open", Article = new string[] { "Hallo IT!", "ich komme nicht auf meine Email Outlook!" } });
            tickets.Add(new TicketModel { Id = "5", UserId = "2", Name = "Ticket05ITA", Created = "14.03.2023:13:30", Status = "open", Article = new string[] { "Hallo IT!", "Hallo IT!", "der Drucker im Gang reagiert nicht" } });
            tickets.Add(new TicketModel { Id = "6", UserId = "2", Name = "Ticket06PS", Created = "16.03.2023:09:10", Status = "closed", Article = new string[] { "Hallo IT!", "wie kann ich mein Laptop mit dem Drucker verbinden?" } });
            tickets.Add(new TicketModel { Id = "7", UserId = "3", Name = "Ticket07PS", Created = "16.03.2023:11:30", Status = "open", Article = new string[] { "Hallo IT!", "Hallo IT!", "mein Laptop ist defekt an der Baterie" } });
            tickets.Add(new TicketModel { Id = "8", UserId = "3", Name = "Ticket08PS", Created = "16.03.2023:10:15", Status = "new", Article = new string[] { "Hallo IT!", "brauche ein neues Headset" } });
            tickets.Add(new TicketModel { Id = "9", UserId = "3", Name = "Ticket09PS", Created = "18.04.2023:08:22", Status = "closed", Article = new string[] { "Hallo IT!", "meine Webcam ist ausgefallen" } });
            tickets.Add(new TicketModel { Id = "10", UserId = "3", Name = "Ticket10PS", Created = "18.04.2023:11:30", Status = "open", Article = new string[] { "Hallo IT!", "der Monitor in der Lounge ist ausgefallen" } });

            ticketsDataGrid.ItemsSource = tickets;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

    }
}
