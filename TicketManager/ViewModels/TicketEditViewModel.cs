using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Printing;
using System.Security.Policy;
using System.Text;
using TicketManager.DataModels;
using TicketManager.Enums;

namespace TicketManager.ViewModels
{
    public class TicketEditViewModel : ViewModelBase
    {
        public string WindowTitle { get; set; }

        public string TicketId => $"#{TicketInfo.Id}";

        public int? ParentTicketId 
        {
            get => TicketInfo.ParentTicketId; 
            set
            {
                TicketInfo.ParentTicketId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 選択中のチケットタイプ
        /// </summary>
        public TicketStatus? SelectedTicketStatus
        {
            get => field;
            set
            {
                field = value;
                TicketInfo.TicketStatusId = value?.Id ?? string.Empty;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 選択中の担当者
        /// </summary>
        public PlayerInfo? SelectedPlayer
        {
            get => field;
            set
            {
                field = value;
                TicketInfo.AssigneeId = value?.Id ?? string.Empty;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 選択中のマイルストーン
        /// </summary>
        public MileStoneInfo? SelectedMilestone
        {
            get => field;
            set
            {
                field = value;
                TicketInfo.MilestoneId = value?.Id ?? string.Empty;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 子チケットビューモデルリスト
        /// </summary>
        public ObservableCollection<TicketItemViewModel> ChildTickets { get; set; } = [];


        public TicketInfo TicketInfo { get; set; }

        /// <summary>
        /// チケットタイプのリスト
        /// </summary>
        public List<TicketTypes> TicketTypeList { get; set; } = [TicketTypes.Epic, TicketTypes.Story, TicketTypes.Task];

        /// <summary>
        /// チケット状態のリスト
        /// </summary>
        public List<TicketStatus> TicketStatusList { get; set; } = AppDataManager.TicketStatusList;

        /// <summary>
        /// 担当者のリスト
        /// </summary>
        public List<PlayerInfo> PlayerList { get; set; } = [Empties.EmptyPlayer, .. AppDataManager.PlayerList];


        /// <summary>
        /// マイルストーンのリスト
        /// </summary>
        public List<MileStoneInfo> MilestoneList { get; set; } = [Empties.EmptyMileStone, .. AppDataManager.MilestoneList];


        public TicketEditViewModel()
        {
            TicketInfo = new TicketInfo();
            TicketInfo.Id = AppDataManager.PublishTicketId();
            WindowTitle = "チケット作成";
        }

        public TicketEditViewModel(TicketInfo ticketInfo)
        {
            TicketInfo = ticketInfo;
            WindowTitle = $"チケット編集 - {TicketId}";
        }

        public void LoadChildTickets()
        {
            ChildTickets.Clear();
            var childIds = AppState.CurrentProject.TicketRelations[TicketInfo.Id].ChildTicketIds;
            childIds.Select( id => AppState.CurrentProject.Tickets[id] ).ToList().ForEach( t => ChildTickets.Add(new TicketItemViewModel(t)) );
        }
    }
}
