using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MODEXngine.lib.Base;
using MODEXngine.ViewModels;

namespace MODEXngine.UnitTests.Launcher
{
    [TestClass]
    public class LauncherAboutViewModelTests
    {
        private void Initialize()
        {
            App.GameHeaders = new List<BaseGameHeader>();
            App.Renderers = new List<BaseRenderer>();
        }

        [TestMethod]
        public void Launcher_AboutViewModel_Constructor_Null()
        {
            var viewModel = new AboutViewModel();

            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void Launcher_AboutViewModel_Constructor_Initialize()
        {
            Initialize();

            var viewModel = new AboutViewModel();

            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void Launcher_AboutViewModel_Constructor_SetGamesNull()
        {
            Initialize();

            var viewModel = new AboutViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.AvailableGames = null;
        }

        [TestMethod]
        public void Launcher_AboutViewModel_Constructor_SetRendererNull()
        {
            Initialize();

            var viewModel = new AboutViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.AvailableRenderers = null;
        }
    }
}