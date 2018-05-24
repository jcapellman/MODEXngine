using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using MODEXngine.Annotations;

namespace MODEXngine.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected List<T> LoadAssemblies<T>(string mask)
        {
            var assemblies = Directory.GetFiles(AppContext.BaseDirectory, mask);

            return (from assembly in assemblies select Assembly.LoadFile(assembly) 
                into asm select asm.GetExportedTypes().FirstOrDefault(a => typeof(T).IsAssignableFrom(a)) 
                into headerType where headerType != null
                select (T) Activator.CreateInstance(headerType)).ToList();
        }
    }
}