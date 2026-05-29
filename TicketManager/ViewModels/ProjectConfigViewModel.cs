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
        /// コンストラクタ
        /// </summary>

        public ProjectConfigViewModel()
        {
            EdittingdPlayer = new PlayerInfo();
            LoadPlayerList();
            AppState.PlayerListChanged += AppState_PlayerListChanged;
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

        private void AppState_PlayerListChanged(object? sender, EventArgs e)
        {
            LoadPlayerList();
        }
    }
}
