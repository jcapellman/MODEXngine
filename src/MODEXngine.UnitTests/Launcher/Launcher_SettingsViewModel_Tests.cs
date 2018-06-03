using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MODEXngine.lib.Base;
using MODEXngine.lib.CommonObjects;
using MODEXngine.renderlib.opengl;
using MODEXngine.ViewModels;

namespace MODEXngine.UnitTests.Launcher
{
    [TestClass]
    public class LauncherSettingsViewModelTests
    {
        private void InitializeSettings()
        {
            App.AppSettings = new Settings();
        }

        private void InitializeRenderers()
        {
            App.Renderers = new List<BaseRenderer>
            {
                new OpenGLRenderer()
            };
        }

        private void InitializeAll()
        {
            InitializeSettings();
            InitializeRenderers();
        }

        [TestMethod]        
        public void Launcher_SettingsViewModel_Constructor_AllNull()
        {
            var viewModel = new SettingsViewModel();

            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void Launcher_SettingsViewModel_Constructor_RenderersNull()
        {
            InitializeSettings();

            var viewModel = new SettingsViewModel();

            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void Launcher_SettingsViewModel_Constructor_ProperlyInitialized()
        {
            InitializeAll();
            
            var viewModel = new SettingsViewModel();

            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void Launcher_SettingsViewModel_SelectedRenderer_Null()
        {
            var viewModel = new SettingsViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.SelectedRenderer = null;
        }

        [TestMethod]
        public void Launcher_SettingsViewModel_SelectedRenderer_Initialized()
        {
            var viewModel = new SettingsViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.SelectedRenderer = new OpenGLRenderer();

            Assert.IsNotNull(viewModel.SelectedRenderer);
        }

        [TestMethod]
        public void Launcher_SettingsViewModel_Settings_Null()
        {
            var viewModel = new SettingsViewModel();

            Assert.IsNotNull(viewModel);

            viewModel.Settings = null;
        }
    }
}