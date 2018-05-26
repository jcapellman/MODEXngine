using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using MODEXngine.Annotations;

namespace MODEXngine.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event EventHandler<string> GUIMessage;

        protected void OnGUIMessage(string message) => GUIMessage?.Invoke(this, message);

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}