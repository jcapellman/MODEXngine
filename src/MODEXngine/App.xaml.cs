using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using MODEXngine.Interfaces;
using MODEXngine.lib;
using MODEXngine.lib.Common;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Managers;
using MODEXngine.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MODEXngine
{
	public partial class App : Application
	{
	    public static Settings AppSettings;

	    public static List<BaseGameHeader> GameHeaders;

	    public static List<BaseRenderer> Renderers;

	    private static List<T> LoadAssemblies<T>(string mask)
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

	    private static void InitializeLocalization()
	    {
	        var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
	        Resx.AppResources.Culture = ci;
	        DependencyService.Get<ILocalize>().SetLocale(ci);
        }

	    private static void InitializeAssemblies()
	    {
	        AppSettings = SettingsManager.LoadSettings(Constants.FILE_NAME_SETTINGS);

	        GameHeaders = LoadAssemblies<BaseGameHeader>(Constants.ASSEMBLY_MASK_GAME_LIBS);

	        Renderers = LoadAssemblies<BaseRenderer>(Constants.ASSEMBLY_MASK_RENDER_LIBS);
        }

        public App ()
		{
			InitializeComponent();

		    InitializeLocalization();    
          
            InitializeAssemblies();
            
            MainPage = new MasterView();
        }
	}
}