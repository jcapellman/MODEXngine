using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace MODEXngine.WPF
{
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Forms.Init();
            LoadApplication(new MODEXngine.App());
        }
    }
}