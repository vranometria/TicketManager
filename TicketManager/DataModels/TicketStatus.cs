using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class TicketStatus
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// このステータスはチケットがクローズされた状態を表すか
        /// </summary>
        public bool IsTicketClosed { get; set; } = false;
        
        /// <summary>
        /// ステータスのラベル
        /// </summary>
        public string Label { get; set; } = string.Empty;
    }
}
