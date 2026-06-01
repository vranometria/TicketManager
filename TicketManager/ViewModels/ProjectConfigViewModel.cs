using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager.ViewModels
{
    public class ProjectConfigViewModel : ViewModelBase
    {
        /// <summary>
        /// 編集中の作業者プロパティ
        /// </summary>
        public PlayerInfo EdittingdPlayer { get => field; set { field = value; OnPropertyChanged(); } }

        /// <summary>
        /// リスト表示する作業者一覧
        /// </summary>
        public ObservableCollection<PlayerInfo> Players { get; set; } = [];

        /// <summary>
        /// 編集中のチケットステータス
        /// </summary>
        public TicketStatus EdittingTicketStatus { get => field; set { field = value; OnPropertyChanged(); } }

        /// <summary>
        /// チケットステータス一覧
        /// </summary>
        public ObservableCollection<TicketStatus> TicketStatuses { get; set; } = [];

        public MileStoneInfo EdittingMilestone { get => field; set { field = value; OnPropertyChanged(); } }

        public ObservableCollection<MileStoneInfo> Milestones { get; set; } = [];

        /// <summary>
        /// コンストラクタ
        /// </summary>

        public ProjectConfigViewModel()
        {
            EdittingdPlayer = new PlayerInfo();
            EdittingTicketStatus = new TicketStatus();
            EdittingMilestone = new MileStoneInfo();
            LoadPlayerList();
            LoadticketStatusList();
            LoadMilestoneList();
            AppState.PlayerListChanged += AppState_PlayerListChanged;
            AppState.TicketStatusListChanged += AppState_TicketStatusListChanged;
            AppState.MilestoneListChanged += AppState_MilestoneListChanged;
        }

        private void LoadticketStatusList()
        {
            TicketStatuses.Clear();
            foreach(var s in AppDataManager.TicketStatusList)
            {
                TicketStatuses.Add(s);
            }
        }

        public void SetNewPlayer()
        {
            EdittingdPlayer = new PlayerInfo();
        }

        private void LoadPlayerList()
        {
            Players.Clear();
            foreach(var p in AppDataManager.PlayerList)
            {
                Players.Add(p);
            }
        }

        private void LoadMilestoneList()
        {
            Milestones.Clear();
            foreach(var m in AppDataManager.MilestoneList)
            {
                Milestones.Add(m);
            }
        }

        private void AppState_PlayerListChanged(object? sender, EventArgs e)
        {
            LoadPlayerList();
        }

        private void AppState_TicketStatusListChanged(object? sender, EventArgs e)
        {
            LoadticketStatusList();
        }

        private void AppState_MilestoneListChanged(object? sender, EventArgs e)
        {
            LoadMilestoneList();
        }
    }
}
