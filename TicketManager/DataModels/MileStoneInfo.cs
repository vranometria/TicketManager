using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class MileStoneInfo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Label { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
