using System.Windows;
using System.Windows.Controls;
using TicketFlow.ViewModels;

namespace TicketFlow.Views
{
    /// <summary>
    /// TableView overload > DataContext > TableViewModel
    /// </summary>
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
            DataContext = new TableViewModel();

        }
    }
}
