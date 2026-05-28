using System;
using System.Collections.Generic;
using System.Text;
using TicketManager.Enums;

namespace TicketManager.DataModels
{
    public class TicketInfo
    {
        private static AppDataManager AppDataManager => AppDataManager.Instance;

        /// <summary>
        /// チケット番号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// チケットタイトル
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// チケット概要
        /// </summary>
        public string Abstract { get; set; } = "";

        /// <summary>
        /// エピック、ストーリー、タスクのいずれか
        /// </summary>
        public TicketTypes TicketType { get; set; } = TicketTypes.Epic;

        /// <summary>
        /// 開始日
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 期限日
        /// </summary>
        public DateTime? LimitDate { get; set; }

        /// <summary>
        /// チケット状態
        /// </summary>
        public string TicketStatusId { get; set; } = string.Empty;

        /// <summary>
        /// 作業者Id
        /// </summary>
        public string AssigneeId { get; set; } = string.Empty;

        public TicketInfo() 
        {
            Id = AppDataManager.PublicTicketId();
        }
    }
}
