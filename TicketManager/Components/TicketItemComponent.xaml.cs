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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketManager.SubWindows;
using TicketManager.ViewModels;

namespace TicketManager.Components
{
    /// <summary>
    /// TicketItemComponent.xaml の相互作用ロジック
    /// </summary>
    public partial class TicketItemComponent : UserControl
    {
        private static AppState AppState => AppState.Instance;

        private TicketItemViewModel? ViewModel => DataContext as TicketItemViewModel;

        public TicketItemComponent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// チケットIDをダブルクリックすると、チケット編集ウィンドウを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicketId_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(ViewModel == null)
            {
                return;
            }

            var ticketInfo = AppState.CurrentProject.GetTicketInfo(ViewModel.Id);
            if (ticketInfo != null)
            {
                TicketEditWindow window = new(ticketInfo);
                window.ShowDialog();
            }
        }
    }
}
