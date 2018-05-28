using System.Globalization;
using System.Windows;
using System.Windows.Markup;

using MODEXngine.Interfaces;

using Xamarin.Forms;

[assembly: Dependency(typeof(MODEXngine.WPF.InterfaceImplementations.Localize))]
namespace MODEXngine.WPF.InterfaceImplementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo() => CultureInfo.CurrentCulture;

        public void SetLocale(CultureInfo ci)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(ci.Name)));
        }
    }
}