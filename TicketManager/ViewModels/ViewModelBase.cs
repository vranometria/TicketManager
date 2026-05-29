using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TicketManager.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected static AppDataManager AppDataManager => AppDataManager.Instance;

        protected static AppState AppState => AppState.Instance;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
