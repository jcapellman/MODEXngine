using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

using MODEXngine.Common;
using MODEXngine.lib;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Managers;

namespace MODEXngine
{
    public partial class App : Application
    {
        public static Settings AppSettings;

        public static List<BaseGameHeader> GameHeaders;

        public static List<BaseRenderer> Renderers;

        public App()
        {
            AppSettings = SettingsManager.LoadSettings(Constants.FILE_NAME_SETTINGS);

            GameHeaders = LoadAssemblies<BaseGameHeader>(Constants.ASSEMBLY_MASK_GAME_LIBS);

            Renderers = LoadAssemblies<BaseRenderer>(Constants.ASSEMBLY_MASK_RENDER_LIBS);
        }

        protected List<T> LoadAssemblies<T>(string mask)
        {
            var assemblies = Directory.GetFiles(AppContext.BaseDirectory, mask);

            return (from assembly in assemblies
                select Assembly.LoadFile(assembly)
                into asm
                select asm.GetExportedTypes().FirstOrDefault(a => typeof(T).IsAssignableFrom(a))
                into headerType
                where headerType != null
                select (T)Activator.CreateInstance(headerType)).ToList();
        }
    }
}