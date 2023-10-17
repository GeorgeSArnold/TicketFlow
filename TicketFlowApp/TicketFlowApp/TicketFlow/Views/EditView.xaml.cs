﻿using System.Windows;
using System.Windows.Input;
using TicketFlow.ViewModels;
using Zammad_Lib.Models;

namespace TicketFlow.Views
{
    /// <summary>
    /// Get TicketModel Infos > open Child > new Window
    /// </summary>
    public partial class EditView : Window
    {
        // const
        public TicketModel SelectedTicket { get; set; }
        public EditView(TicketModel selectedTicket)
        {
            InitializeComponent();
            SelectedTicket = selectedTicket;
            DataContext = new EditViewModel(SelectedTicket);
        }

        #region Window Logic
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximized_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }
        #endregion
    }
}
