using System;
using System.Collections.Generic;
using System.Text;
using TicketManager.DataModels;
using TicketManager.ViewModels;

namespace TicketManager
{
    public class AppState
    {
        #region Singleton
        public static AppState Instance => field ??= new AppState();
        private AppState() { }
        #endregion

        private AppDataManager AppDataManager => AppDataManager.Instance;

        public ProjectInfo CurrentProject { get; set; } = Empties.EmptyProject;

        public event EventHandler<EventArgs>? ProjectListChanged;

        public event EventHandler<EventArgs>? ProjectChanged;

        public event EventHandler<EventArgs>? PlayerListChanged;

        public event EventHandler<EventArgs>? TicketStatusListChanged;

        public event EventHandler<EventArgs>? MilestoneListChanged;

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

        public void RaiseTicketStatusListChanged()
        {
            TicketStatusListChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseMilestoneListChanged()
        {
            MilestoneListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
