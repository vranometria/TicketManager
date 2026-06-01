using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TicketManager.DataModels;
using TicketManager.ViewModels;

namespace TicketManager
{
    public class AppDataManager
    {
        #region Singleton
        public static AppDataManager Instance => field ??= new AppDataManager();

        private AppDataManager() { AppData = Load(); }
        #endregion

        private const string APP_DATA_FILE = "appdata.json";

        private AppData AppData { get; set; }

        private AppState AppState { get; set; } = AppState.Instance;

        public List<ProjectInfo> Projects => [.. AppData.ProjectsDictionary.Values.Cast<ProjectInfo>()];

        public List<TicketStatus> TicketStatusList => AppData.TicketStatuses;

        public List<PlayerInfo> PlayerList => AppData.ProjectsDictionary[AppState.CurrentProject.Id].Players;

        public ProjectInfo PreviousProject
        {
            get
            {
                if (!string.IsNullOrEmpty(AppData.PreviousProjectId))
                {
                    return AppData.ProjectsDictionary[AppData.PreviousProjectId];
                }
                else if (AppData.ProjectsDictionary.Count > 0)
                {
                    return AppData.ProjectsDictionary.Values.First();
                }
                else
                {
                    return Empties.EmptyProject;
                }
            }
        }

        public List<MileStoneInfo> MilestoneList => AppData.ProjectsDictionary[AppState.CurrentProject.Id].Milestones;

        private AppData Load()
        {
            if (File.Exists(APP_DATA_FILE))
            {
                string json = File.ReadAllText(APP_DATA_FILE);
                return JsonSerializer.Deserialize<AppData>(json) ?? new AppData();
            }
            return new AppData();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(AppData);
            File.WriteAllText(APP_DATA_FILE, json);
        }

        public ProjectInfo? GetProjectById(string projectId)
        {
            if (!AppData.ProjectsDictionary.ContainsKey(projectId))
            {
                return null;
            }
            return AppData.ProjectsDictionary[projectId];
        }

        public void AddProject(ProjectInfo projectInfo)
        {
            AppData.ProjectsDictionary[projectInfo.Id] = projectInfo;
            AppState.RaiseProjectListChanged();
        }

        public int PublicTicketId()
        {
            int id = AppData.NextTicketId;
            AppData.NextTicketId++;
            return id;
        }

        public void AddTicket(string projectId, TicketInfo ticketInfo)
        {
            GetProjectById(projectId).Tickets[ticketInfo.Id] = ticketInfo;
        }

        public void AddTickets(string id, List<TicketInfo> tickets)
        {
            tickets.ForEach(t => AddTicket(id, t));
        }

        public void DeletePlayer(string id)
        {
            AppData.ProjectsDictionary[AppState.CurrentProject.Id].Players.RemoveAll(p => p.Id == id);
            AppState.RaisePlayerListChanged();
        }

        internal void AddPlayer(PlayerInfo edittingdPlayer)
        {
            int i = AppState.CurrentProject.Players.FindIndex(p => p.Id == edittingdPlayer.Id);
            if (i == -1)
            {
                AppData.ProjectsDictionary[AppState.CurrentProject.Id].Players.Add(edittingdPlayer);
            }
            else
            {
                AppData.ProjectsDictionary[AppState.CurrentProject.Id].Players[i] = edittingdPlayer;
            }

            AppState.RaisePlayerListChanged();
        }

        internal void AddTicketStatus(TicketStatus edittingTicketStatus)
        {
            int i = AppData.TicketStatuses.FindIndex(s => s.Id == edittingTicketStatus.Id);
            if (i == -1)
            {
                AppData.TicketStatuses.Add(edittingTicketStatus);
            }
            else
            {
                AppData.TicketStatuses[i] = edittingTicketStatus;
            }
            AppState.RaiseTicketStatusListChanged();
        }

        public void AddMilestone(MileStoneInfo edittingMilestone)
        {
            int i = AppState.CurrentProject.Milestones.FindIndex(m => m.Id == edittingMilestone.Id);
            if (i == -1)
            {
                AppData.ProjectsDictionary[AppState.CurrentProject.Id].Milestones.Add(edittingMilestone);
            }
            else
            {
                AppData.ProjectsDictionary[AppState.CurrentProject.Id].Milestones[i] = edittingMilestone;
            }
            AppState.RaiseMilestoneListChanged();
        }
    }
}
