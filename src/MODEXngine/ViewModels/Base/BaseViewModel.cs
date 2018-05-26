using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MODEXngine.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event EventHandler<string> GUIMessage;

        protected void OnGUIMessage(string message) => GUIMessage?.Invoke(this, message);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}