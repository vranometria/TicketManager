using System;
using System.Collections.Generic;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager
{
    public class AppState
    {
        #region Singleton
        public static AppState Instance => field ??= new AppState();
        private AppState() { }
        #endregion

        private AppDataManager AppDataManager => AppDataManager.Instance;

        public ProjectInfo CurrentProject { get; set; } = ProjectInfo.Empty;

        public event EventHandler<EventArgs>? ProjectListChanged;

        public event EventHandler<EventArgs>? ProjectChanged;

        public event EventHandler<EventArgs>? PlayerListChanged;

        public void ChangeProject(string projectId)
        {
            var project = AppDataManager.GetProjectById(projectId);
            if (project != null)
            {
                CurrentProject = project;
                RaiseProjectChanged();
            }
        }

        public void RaiseProjectListChanged()
        {
            ProjectListChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseProjectChanged()
        {
            ProjectChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaisePlayerListChanged()
        {
            PlayerListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
