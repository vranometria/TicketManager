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
    /// ProjectConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ProjectConfigWindow : Window
    {
        private static AppDataManager AppDataManager => AppDataManager.Instance;

        private ProjectConfigViewModel ViewModel { get; set; } = new ();

        public ProjectConfigWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void PlayerDeleteButton_Clicked(object sender, RoutedEventArgs e)
        {
            AppDataManager.DeletePlayer(ViewModel.EdittingdPlayer.Id);
        }

        private void RegisterPlayerButton_Clicked(object sender, RoutedEventArgs e)
        {
            if(ViewModel.EdittingdPlayer.Name == string.Empty)
            {
                MessageBox.Show("プレイヤー名を入力してください");
                return;
            }

            AppDataManager.AddPlayer(ViewModel.EdittingdPlayer);
            ViewModel.SetNewPlayer();
        }

        private void CloseButton_Clicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
