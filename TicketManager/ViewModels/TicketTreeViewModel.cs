using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager.ViewModels
{
    public class TicketTreeViewModel : ViewModelBase
    {
        public ObservableCollection<TicketItemViewModel> Tickets { get; set; } = [];


        public TicketTreeViewModel() { }

        public TicketTreeViewModel(List<TicketInfo> ticketInfos)
        {
            LoadTickets(ticketInfos);
        }


        public void LoadTickets(List<TicketInfo> ticketInfos)
        {
            Tickets.Clear();
            foreach (var ticketInfo in ticketInfos)
            {
                TicketItemViewModel vm = new(ticketInfo);
                Tickets.Add(vm);
            }
        }
    }
}
