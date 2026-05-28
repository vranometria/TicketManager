using Microsoft.VisualBasic;
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
using TicketManager.DataModels;
using TicketManager.ViewModels;

namespace TicketManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel = new();

        private AppDataManager AppDataManager { get; set; } = AppDataManager.Instance;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private ProjectInfo? CreateNewProject()
        {
            string projectName = Interaction.InputBox("プロジェクト名を入力してください", "プロジェクト作成", "DefaultProject", -1, -1);
            if (!string.IsNullOrEmpty(projectName))
            {
                return new ProjectInfo(projectName);
            }
            return null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ProjectInfo == ProjectInfo.Empty)
            {
                var newProject = CreateNewProject();
                if (newProject != null)
                {
                    ViewModel.ProjectInfo = newProject;
                    AppDataManager.AddProject(newProject);
                }
                else
                {
                    Close();
                }
            }
        }

        private void NewProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ProjectInfo? newProject = CreateNewProject();
            if (newProject != null)
            {
                ViewModel.ProjectInfo = newProject;
                AppDataManager.AddProject(newProject);
            }
        }

        private void OpenProjectMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            ProjectInfo? projectInfo = menuItem?.DataContext as ProjectInfo;
            if (projectInfo != null)
            {
                ViewModel.ProjectInfo = projectInfo;
            }
        }
    }
}