using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class ProjectInfo
    {
        private static readonly ProjectInfo EmptyInstance = new ProjectInfo(string.Empty);

        public static ProjectInfo Empty => EmptyInstance;

        /// <summary>
        /// プロジェクト識別子
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// プロジェクト名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作業者情報
        /// </summary>
        public List<PlayerInfo> Players { get; set; } = [];

        /// <summary>
        /// 全チケット
        /// </summary>
        public Dictionary<int, TicketInfo> Tickets { get; set; } = [];


        public ProjectInfo(string name)
        { 
            Name = name;
        }
    }
}
