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
    }
}
