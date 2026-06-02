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
using TicketManager.ViewModels;

namespace TicketManager.Components
{
    /// <summary>
    /// TicketTreeComponent.xaml の相互作用ロジック
    /// </summary>
    public partial class TicketTreeComponent : UserControl
    {
        private TicketTreeViewModel? ViewModel => DataContext as TicketTreeViewModel;

        public TicketTreeComponent()
        {
            InitializeComponent();
        }
    }
}
