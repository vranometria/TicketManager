using System;
using System.Collections.Generic;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager.ViewModels
{
    public class TicketEditViewModel : ViewModelBase
    {
        public string WindowTitle { get; set; }

        public string TicketId => $"#{TicketInfo.Id}";

        public TicketInfo TicketInfo { get; set; }

        public TicketEditViewModel()
        {
            TicketInfo = new TicketInfo();
            WindowTitle = "チケット作成";
        }
    }
}
