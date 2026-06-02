using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class AppData
    {
        public Dictionary<string, ProjectInfo> ProjectsDictionary { get; set; } = [];

        /// <summary>
        /// 次に発行するチケットID
        /// </summary>
        public int NextTicketId { get; set; } = 0;

        

        /// <summary>
        /// 前回開いていたプロジェクトID
        /// </summary>
        public string PreviousProjectId { get; set; } = string.Empty;

        /// <summary>
        /// チケットの状態
        /// </summary>

        public List<TicketStatus> TicketStatuses { get; internal set; } = [
                new TicketStatus(){ Label = "未着手" },
                new TicketStatus(){ Label = "進行中",},
                new TicketStatus(){ Label = "完了", },
            ];
    }
}
