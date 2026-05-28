using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class AppData
    {
        public List<ProjectInfo> Projects { get; set; } = [];

        /// <summary>
        /// 次に発行するチケットID
        /// </summary>
        public int NextTicketId { get; set; } = 0;

        /// <summary>
        /// チケットの親子関係
        /// </summary>
        public Dictionary<int, TicketRelation> TicketRelations { get; set; } = [];

        /// <summary>
        /// チケットの状態
        /// </summary>

        public List<TicketStatus> TicketStatuses { get; internal set; } = [];

        /// <summary>
        /// 作業者情報
        /// </summary>
        public List<PlayerInfo> Players { get; internal set; } = [];

        public AppData()
        {
            TicketStatuses = [
                new TicketStatus()                {
                    Label = "未着手",
                },
                new TicketStatus()                {
                    Label = "進行中",
                },
                new TicketStatus()                {
                    Label = "完了",
                }
                ];
        }
    }
}
