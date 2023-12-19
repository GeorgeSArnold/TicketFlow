using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TicketFlow.Utilitys;
using TicketFlow.Views;
using Zammad_Lib;
using Zammad_Lib.Models;

namespace TicketFlow.ViewModels
{
    public class TableViewModel : Caliburn.Micro.Screen
    {
        // datagrid
        private DataGrid myDataGrid;
        public DataGrid MyDataGrid
        {
            get { return myDataGrid; }
            set { myDataGrid = value; }
        }

        // ticket list
        public BindableCollection<TicketModel> TicketList
        {
            get { return ticketList; }
            set
            {
                ticketList = value;
                NotifyOfPropertyChange(() => TicketList);
            }
        }
        private BindableCollection<TicketModel> ticketList;

        //const
        public TableViewModel()
        {
            MyDataGrid = new DataGrid();
            LoadDataTable();
        }

        // load data
        //public async Task LoadDataTable()
        //{
        //    try
        //    {
        //        List<TicketModel> tickets = new List<TicketModel>();
        //        // load connection
        //        TicketProcessor ticketProcessor = TicketProcessor.Instance;
        //        APISettingsViewModel asvm = new APISettingsViewModel();

        //        // get connection
        //        string serverIP = asvm.GetServerIp();
        //        string zammadToken = asvm.GetZammadToken();

        //        // load ticket
        //        tickets = await ticketProcessor.LoadTickets(serverIP, zammadToken);

        //        // check loaded ticket
        //        if (tickets != null)
        //        {
        //            // load tickets > bindableCollection > datagrid UI
        //            TicketList = new BindableCollection<TicketModel>(tickets);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("invalid ticket id... " + ex.Message);
        //    }
        //}

        // methods

        //public void RefreshTable(List<TicketModel> tickets)
        //{
        //    if (TicketList != null)
        //    {
        //        Console.WriteLine("# Refreshing TableView");
        //        TicketList.Clear();
        //        LoadDataTable();
        //        NotifyOfPropertyChange(() => TicketList);
        //    }
        //}

        // bind EditTicket() > UI
        private ICommand editTicketCommand;
        public ICommand EditTicketCommand
        {
            get
            {
                if (editTicketCommand == null)
                    editTicketCommand = new RelayCommand(param => EditTicket());
                return editTicketCommand;
            }
        }

        // selected Ticket > EditView
        private TicketModel selectedTicket;
        public TicketModel SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
            }
        }
        // obj
        public TicketModel GetSelectedTicket()
        {
            return SelectedTicket;
        }

        // open > Window
        public void EditTicket()
        {
            Console.WriteLine("-> Edit-Ticket clicked");

            TicketModel selectedTicket = SelectedTicket;

            Console.WriteLine("Selected Ticket ID: " + (selectedTicket != null ? selectedTicket.Id.ToString() : "null"));

            if (selectedTicket != null)
            {
                EditViewModel editViewModel = new EditViewModel(selectedTicket);
                EditView ev = new EditView(selectedTicket);
                ev.DataContext = editViewModel;
                ev.Show();
            }
            else
            {
                MessageBox.Show("Please choose ticket");
            }
        }

        //TODO: paging
        // Felder > paging: left arrow, right arrow, pagenumber

        public static void LeftArrow()
        {
            Console.WriteLine("-> Left Arrow pressed");
        }

        private int siteNumber;
        public int PageNumber
        {
            get { return siteNumber; }
            set
            {
                siteNumber = value;
                NotifyOfPropertyChange(() => siteNumber.ToString());
            }
        }


        public static void RightArrow()
        {
            Console.WriteLine("-> Right Arrow pressed");
        }

        // TODO: modify mathode whit paging
        public async Task LoadDataTable()
        {
            try
            {
                List<TicketModel> tickets = new List<TicketModel>();
                // load connection
                TicketProcessor ticketProcessor = TicketProcessor.Instance;
                APISettingsViewModel asvm = new APISettingsViewModel();

                // get connection
                string serverIP = asvm.GetServerIp();
                string zammadToken = asvm.GetZammadToken();

                // load ticket
                tickets = await ticketProcessor.LoadTickets(serverIP, zammadToken);

                // check loaded ticket
                if (tickets != null)
                {
                    // load tickets > bindableCollection > datagrid UI
                    TicketList = new BindableCollection<TicketModel>(tickets);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid ticket id... " + ex.Message);
            }
        }


    }
}
