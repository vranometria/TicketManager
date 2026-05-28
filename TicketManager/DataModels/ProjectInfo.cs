using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager.DataModels
{
    public class ProjectInfo
    {
        private static readonly ProjectInfo EmptyInstance = new ProjectInfo(string.Empty);

        public static ProjectInfo Empty => EmptyInstance;

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public ProjectInfo(string name)
        { 
            Name = name;
        }
    }
}
