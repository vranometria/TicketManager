using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {

        public ProjectInfo ProjectInfo { get => field; set { field = value; OnPropertyChanged(); } } = Empties.EmptyProject;

        public ObservableCollection<ProjectInfo> Projects { get; set; } = [];



        public MainWindowViewModel()
        {
            AppState.ProjectListChanged += AppState_ProjectListChanged;
            AppState.ProjectChanged += AppState_ProjectChanged;
        }

        private void AppState_ProjectChanged(object? sender, EventArgs e)
        {
            ProjectInfo = AppState.CurrentProject;
        }

        private void AppState_ProjectListChanged(object? sender, EventArgs e)
        {
            Projects.Clear();
            AppDataManager.Projects.ForEach(p => Projects.Add(p) );
        }
    }
}
