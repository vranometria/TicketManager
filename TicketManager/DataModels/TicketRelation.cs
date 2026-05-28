using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class TicketRelation
    {
        public int ParentTicketId { get; set; }

        public List<int> ChildTicketIds { get; set; } = [];
    }
}
