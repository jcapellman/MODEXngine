using Android.App;
using Android.OS;
using Android.Content.PM;

namespace MODEXngine.Android {
    [Activity(Label = "MODEXngine",
        MainLauncher = true,
        Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden
    )]
    public class MainActivity : Activity {
        GLMainView view;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            view = new GLMainView(this);
            SetContentView(view);
        }

        protected override void OnPause() {
            base.OnPause();
            view.Pause();
        }

        protected override void OnResume() {
            base.OnResume();
            view.Resume();
        }
    }
}