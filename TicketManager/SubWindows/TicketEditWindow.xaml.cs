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
        private static AppState AppState => AppState.Instance;

        private readonly TicketEditViewModel ViewModel;

        public int? ParentTicketId => ViewModel.ParentTicketId;

        /// <summary>
        ///  新規チケットかチケット編集か
        /// </summary>
        public bool IsNewTicket = false;

        public TicketEditWindow(TicketInfo ticketInfo) : this(new TicketEditViewModel(ticketInfo)) { IsNewTicket = false; }

        public TicketEditWindow() : this(new TicketEditViewModel()) { IsNewTicket = true; }

        public TicketEditWindow(TicketEditViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = ViewModel;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsNewTicket)
            {
                ChildTicketsGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void OKButton_Clicked(object sender, RoutedEventArgs e)
        {
            AppState.CurrentProject.AddTicket(ParentTicketId, ViewModel.TicketInfo);
            DialogResult = true;
        }

        private void NewChildTicketButton_Click(object sender, RoutedEventArgs e)
        {
            TicketInfo ticketInfo = new TicketInfo();
            ticketInfo.Id = AppDataManager.Instance.PublishTicketId();
            TicketEditViewModel vm = new TicketEditViewModel(ticketInfo);
            vm.ParentTicketId = ViewModel.TicketInfo.Id;
            TicketEditWindow window = new(vm);
            if (window.ShowDialog() == true)
            { 
                ViewModel.LoadChildTickets();
            }
        }
    }
}
