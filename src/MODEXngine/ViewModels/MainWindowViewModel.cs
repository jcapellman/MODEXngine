using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

using MODEXngine.lib;

namespace MODEXngine.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<BaseGameHeader> _gameHeaders;

        public ObservableCollection<BaseGameHeader> GameHeaders
        {
            get => _gameHeaders;
            set { _gameHeaders = value; OnPropertyChanged(); }
        }

        public void LoadVM()
        {
            GameHeaders = new ObservableCollection<BaseGameHeader>();

            var assemblies = Directory.GetFiles(AppContext.BaseDirectory, "MODEXngine.lib.*.dll");

            foreach (var assembly in assemblies)
            {
                var asm = Assembly.LoadFile(assembly);

                var headerType = asm.GetExportedTypes().FirstOrDefault(a => typeof(BaseGameHeader).IsAssignableFrom(a));

                if (headerType == null)
                {
                    continue;
                }

                GameHeaders.Add((BaseGameHeader)Activator.CreateInstance(headerType));
            }
        }
    }
}