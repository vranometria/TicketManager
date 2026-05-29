using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class PlayerInfo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        public string Yomi { get; set; } = string.Empty;
    }
}
