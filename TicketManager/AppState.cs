using System;
using System.Collections.Generic;
using System.Text;

namespace TicketManager
{
    class AppState
    {
        #region Singleton
        public static AppState Instance => field ??= new AppState();
        private AppState() { }
        #endregion

        public event EventHandler<EventArgs>? ProjectListChanged;

        public void RaiseProjectListChanged()
        {
            ProjectListChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
