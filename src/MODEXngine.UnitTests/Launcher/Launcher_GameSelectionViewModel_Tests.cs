using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MODEXngine.lib.Base;
using MODEXngine.ViewModels;

namespace MODEXngine.UnitTests.Launcher
{
    [TestClass]
    public class LauncherGameSelectionViewModelTests
    {
        private void Initialize()
        {
            App.GameHeaders = new List<BaseGameHeader>();
        }

        [TestMethod]
        public void Launcher_GameSelectionViewModel_Constructor_Null()
        {
            var viewModel = new GameSelectionViewModel();

            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void Launcher_GameSelectionViewModel_Constructor_Initialized()
        {
            Initialize();

            var viewModel = new GameSelectionViewModel();

            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void Launcher_GameSelectionViewModel_GameHeaders_Null()
        {
            Initialize();

            var viewModel = new GameSelectionViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.GameHeaders = null;
        }

        [TestMethod]
        public void Launcher_GameSelectionViewModel_SelectedGameHeader_Null()
        {
            Initialize();

            var viewModel = new GameSelectionViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.SelectedGameHeader = null;
        }

        [TestMethod]
        public void Launcher_GameSelectionViewModel_LaunchGamePath_Null()
        {
            Initialize();

            var viewModel = new GameSelectionViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.LaunchGamePath = null;
        }
    }
}