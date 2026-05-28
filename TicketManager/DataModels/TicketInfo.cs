using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class TicketInfo
    {
        private static AppDataManager AppDataManager => AppDataManager.Instance;

        public int Id { get; set; }

        public string Title { get; set; } = "aaaaaa";

        public TicketInfo() 
        {
            Id = AppDataManager.PublicTicketId();
        }
    }
}
