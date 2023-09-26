using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketFlow.Views;

namespace TicketFlow.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        //private LoginViewModel _loginVM;

        //public MainViewModel(LoginViewModel loginVM)
        //{
        //    _loginVM = loginVM;
        //    ActivateItemAsync(loginVM);
        //}

        // dynamic title
        private string activeItemTitle;
        public string ActiveItemTitle
        {
            get { return activeItemTitle; }
            set
            {
                activeItemTitle = value;
                NotifyOfPropertyChange(() => ActiveItemTitle);
            }
        }

        //load child elements >
        public void LoadDashboard()
        {
            ActivateItemAsync(new DashboardViewModel());
            ActiveItemTitle = "Dashboard";

        }

        public void LoadtableView()
        {
            ActivateItemAsync(new TableViewModel());
            ActiveItemTitle = "Table View";
        }

        public void LoadAPISettings()
        {
            ActivateItemAsync(new APISettingsViewModel());
            ActiveItemTitle = "API Settings";
        }

        public void LoadAbout()
        {
            ActiveItemTitle = "About";
            ActivateItemAsync(new AboutViewModel());

        }

        public void LoadLogin()
        {
            ActiveItemTitle = "Login";
            
            ActivateItemAsync(new LoginViewModel());
        }
    }


}
