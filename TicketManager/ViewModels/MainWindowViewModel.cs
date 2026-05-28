using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ProjectInfo ProjectInfo { get => field; set { field = value; OnPropertyChanged(); } } = ProjectInfo.Empty;

        public ObservableCollection<ProjectInfo> Projects { get; set; } = [];

        private AppState AppState { get; set; } = AppState.Instance;

        private AppDataManager AppDataManager { get; set; } = AppDataManager.Instance;

        public MainWindowViewModel()
        {
            AppState.ProjectListChanged += AppState_ProjectListChanged;
        }

        private void AppState_ProjectListChanged(object? sender, EventArgs e)
        {
            Projects.Clear();
            AppDataManager.Projects.ForEach(p => Projects.Add(p) );
        }
    }
}
