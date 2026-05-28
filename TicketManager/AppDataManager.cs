using System;
using System.Collections.Generic;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager
{
    public class AppDataManager
    {
        #region Singleton
        public static AppDataManager Instance => field ??= new AppDataManager();

        private AppDataManager() { AppData = Load(); }
        #endregion


        private AppData AppData { get; set; }

        private AppState AppState { get; set; } = AppState.Instance;

        public List<ProjectInfo> Projects => AppData.Projects;

        private AppData Load() 
        {
            return new AppData();
        }


        public void AddProject(ProjectInfo projectInfo)
        {
            AppData.Projects.Add(projectInfo);
            AppState.RaiseProjectListChanged();
        }
    }
}
