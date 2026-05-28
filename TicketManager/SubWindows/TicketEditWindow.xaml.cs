using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicketManager.DataModels;
using TicketManager.ViewModels;

namespace TicketManager.SubWindows
{
    /// <summary>
    /// TicketEditWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class TicketEditWindow : Window
    {
        private TicketEditViewModel ViewModel;

        public List<TicketInfo> Tickets = [];


        public TicketEditWindow() : this(new TicketEditViewModel()) {}

        public TicketEditWindow(TicketEditViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }

        private void OKButton_Clicked(object sender, RoutedEventArgs e)
        {
            Tickets.Add(ViewModel.TicketInfo);
            DialogResult = true;
        }
    }
}
