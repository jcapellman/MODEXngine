using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

using MODEXngine.Interfaces;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MODEXngine.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci = null;
        const string ResourceId = "MODEXngine.Resx.AppResources";

        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public TranslateExtension()
        {
            ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            var translation = ResMgr.Value.GetString(Text, ci);
            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    $"Key '{Text}' was not found in resources '{ResourceId}' for culture '{ci.Name}'.",
                    "Text");
#else
				translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }
}