using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

using MODEXngine.lib;

using Prism.Commands;

namespace MODEXngine.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand GotoWebsiteCommand =>
            new DelegateCommand(() => System.Diagnostics.Process.Start("https://github.com/jcapellman/MODEXngine"));

        public ICommand LaunchGameCommand => new DelegateCommand( () =>
        {
            _selectedRenderer.SetGameHeader(SelectedGameHeader);
            _selectedRenderer.Render();
        });

        private ObservableCollection<BaseGameHeader> _gameHeaders;

        public ObservableCollection<BaseGameHeader> GameHeaders
        {
            get => _gameHeaders;
            set { _gameHeaders = value; OnPropertyChanged(); }
        }


        private ObservableCollection<BaseRenderer> _renderers;

        public ObservableCollection<BaseRenderer> Renderers
        {
            get => _renderers;
            set { _renderers = value; OnPropertyChanged(); }
        }


        private BaseGameHeader _selectedGameHeader;

        public BaseGameHeader SelectedGameHeader
        {
            get => _selectedGameHeader;

            set { _selectedGameHeader = value; OnPropertyChanged(); }
        }

        private BaseRenderer _selectedRenderer;

        public BaseRenderer SelectedRenderer
        {
            get => _selectedRenderer;

            set { _selectedRenderer = value; OnPropertyChanged(); }
        }

        private bool _btnStartGameEnabled;

        public bool btnStartGameEnabled
        {
            set { _btnStartGameEnabled = value; OnPropertyChanged(); }
            get => _btnStartGameEnabled;
        }

        private List<BaseGameHeader> LoadGames()
        {
            var gameHeaders = new List<BaseGameHeader>();

            var assemblies = Directory.GetFiles(AppContext.BaseDirectory, "MODEXngine.lib.*.dll");

            foreach (var assembly in assemblies)
            {
                var asm = Assembly.LoadFile(assembly);

                var headerType = asm.GetExportedTypes().FirstOrDefault(a => typeof(BaseGameHeader).IsAssignableFrom(a));

                if (headerType == null)
                {
                    continue;
                }

                gameHeaders.Add((BaseGameHeader)Activator.CreateInstance(headerType));
            }

            return gameHeaders;
        }

        private List<BaseRenderer> LoadRenderers()
        {
            var renderers = new List<BaseRenderer>();

            var assemblies = Directory.GetFiles(AppContext.BaseDirectory, "MODEXngine.renderlib.*.dll");

            foreach (var assembly in assemblies)
            {
                var asm = Assembly.LoadFile(assembly);

                var headerType = asm.GetExportedTypes().FirstOrDefault(a => typeof(BaseRenderer).IsAssignableFrom(a));

                if (headerType == null)
                {
                    continue;
                }

                renderers.Add((BaseRenderer)Activator.CreateInstance(headerType));
            }

            return renderers;
        }

        public void LoadVM()
        {
            btnStartGameEnabled = false;

            GameHeaders = new ObservableCollection<BaseGameHeader>(LoadGames().OrderBy(a => a.GameName));

            if (GameHeaders.Any())
            {
                SelectedGameHeader = GameHeaders.FirstOrDefault();
            }

            Renderers = new ObservableCollection<BaseRenderer>(LoadRenderers().OrderBy(a => a.Name));

            if (Renderers.Any())
            {
                _selectedRenderer = Renderers.FirstOrDefault();
            }
            
            btnStartGameEnabled = true;
        }
    }
}