using System;
using System.Collections.Generic;
using System.Text;
using TicketManager.DataModels;

namespace TicketManager.ViewModels
{
    public class Empties
    {
        public static readonly ProjectInfo EmptyProject = new(string.Empty);

        public static readonly MileStoneInfo EmptyMileStone = new() { Id = string.Empty, Label = string.Empty };

        public static readonly PlayerInfo EmptyPlayer = new() { Id = string.Empty, Name = string.Empty };
    }
}
