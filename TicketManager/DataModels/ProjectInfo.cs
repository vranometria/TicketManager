using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class ProjectInfo(string name)
    {
        /// <summary>
        /// プロジェクト識別子
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string Name { get; set; } = name;

        /// <summary>
        /// 作業者情報
        /// </summary>
        public List<PlayerInfo> Players { get; set; } = [];

        /// <summary>
        /// 全チケット
        /// </summary>
        public Dictionary<int, TicketInfo> Tickets { get; set; } = [];

        /// <summary>
        /// マイルストーン
        /// </summary>
        public List<MileStoneInfo> Milestones { get; set; } = [];

        /// <summary>
        /// チケットの親子関係
        /// </summary>
        public Dictionary<int, TicketRelation> TicketRelations { get; set; } = [];


        public List<int> GetChildTicketIds(int ticketId)
        {
            if (!TicketRelations.ContainsKey(ticketId))
            {
                return [];
            }


            TicketRelation rel = TicketRelations[ticketId];
            return rel.ChildTicketIds;
        }

        public TicketInfo? GetTicketInfo(int ticketId)
        {
            if (!Tickets.ContainsKey(ticketId))
            {
                return null;
            }
            return Tickets[ticketId];
        }


        public void AddTicket(int? parentTicketId, TicketInfo ticketInfo)
        {
            Tickets[ticketInfo.Id] = ticketInfo;

            if (parentTicketId != null) 
            {
                if (!TicketRelations.ContainsKey(parentTicketId.Value))
                {
                    TicketRelations[parentTicketId.Value] = new TicketRelation { ParentTicketId = parentTicketId.Value, ChildTicketIds = new List<int> { ticketInfo.Id } };
                }
                else
                {
                    TicketRelations[parentTicketId.Value].ChildTicketIds.Add(ticketInfo.Id);
                }
            }

        }
    }
}
