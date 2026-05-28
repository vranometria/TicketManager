using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using TicketManager.DataModels;
using TicketManager.Enums;

namespace TicketManager.ViewModels
{
    public class TicketEditViewModel : ViewModelBase
    {
        private static AppDataManager AppDataManager => AppDataManager.Instance; 

        public string WindowTitle { get; set; }

        public string TicketId => $"#{TicketInfo.Id}";

        public int? ParentTicketId { get; set; }

        public TicketStatus? SelectedTicketStatus { get => field;
            set 
            {
                field = value;
                TicketInfo.TicketStatusId = value?.Id ?? string.Empty;
                OnPropertyChanged();
            } 
        }

        public PlayerInfo? SelectedPlayer { get => field;
            set
            {
                field = value;
                TicketInfo.AssigneeId = value?.Id ?? string.Empty;
                OnPropertyChanged();
            }
        }

        public TicketInfo TicketInfo { get; set; }

        public List<TicketTypes> TicketTypeList { get; set; } = [TicketTypes.Epic, TicketTypes.Story, TicketTypes.Task];

        public List<TicketStatus> TicketStatusList { get; set; } = AppDataManager.TicketStatusList;

        public List<PlayerInfo> PlayerList { get; set; } = AppDataManager.PlayerList;

        public TicketEditViewModel()
        {
            TicketInfo = new TicketInfo();
            WindowTitle = "チケット作成";
        }
    }
}
