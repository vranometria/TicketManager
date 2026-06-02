using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager.ViewModels
{
    public class TicketItemViewModel : ViewModelBase
    {
        public int Id { get; set; } = 0;

        public string Title { get; set; } = string.Empty;

        public ObservableCollection<TicketItemViewModel> Items { get; set; } = [];

        public TicketItemViewModel() { }

        public TicketItemViewModel(TicketInfo ticketInfo)
        {
            LoadTicketInfo(ticketInfo);
        }


        public void LoadTicketInfo(TicketInfo ticketInfo)
        {
            Id = ticketInfo.Id;
            Title = ticketInfo.Title;

            AppState.CurrentProject.GetChildTicketIds(ticketInfo.Id).ForEach(id =>
             {
                 var childTicketInfo = AppState.CurrentProject.GetTicketInfo(id);
                 if (childTicketInfo != null)
                 {
                     var childItem = new TicketItemViewModel(childTicketInfo);
                     Items.Add(childItem);
                 }
             });
        }
    }
}
