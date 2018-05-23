using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

using MODEXngine.lib;
using MODEXngine.renderlib.opengl;

using Prism.Commands;

namespace MODEXngine.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseRenderer _selectedRenderer;

        public ICommand GotoWebsiteCommand =>
            new DelegateCommand(() => System.Diagnostics.Process.Start("https://github.com/jcapellman/MODEXngine"));

        public ICommand LaunchGameCommand => new DelegateCommand( () => _selectedRenderer.Render());

        private ObservableCollection<BaseGameHeader> _gameHeaders;

        public ObservableCollection<BaseGameHeader> GameHeaders
        {
            get => _gameHeaders;
            set { _gameHeaders = value; OnPropertyChanged(); }
        }

        private BaseGameHeader _selectedGameHeader;

        public BaseGameHeader SelectedGameHeader
        {
            get => _selectedGameHeader;

            set { _selectedGameHeader = value; OnPropertyChanged(); }
        }

        private bool _btnStartGameEnabled;

        public bool btnStartGameEnabled
        {
            set { _btnStartGameEnabled = value; OnPropertyChanged(); }
            get => _btnStartGameEnabled;
        }

        public void LoadVM()
        {
            btnStartGameEnabled = false;

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

            GameHeaders = new ObservableCollection<BaseGameHeader>(GameHeaders.OrderBy(a => a.GameName));

            if (!GameHeaders.Any())
            {
                return;
            }

            SelectedGameHeader = GameHeaders.FirstOrDefault();

            _selectedRenderer = new OpenGLRenderer(SelectedGameHeader);

            btnStartGameEnabled = true;
        }
    }
}