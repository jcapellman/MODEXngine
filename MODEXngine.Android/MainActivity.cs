using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace MODEXngine.Android {
    [Activity(Label = "MODEXngine.Android",
        MainLauncher = true,
        Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden
#if __ANDROID_11__
		,HardwareAccelerated=false
#endif
)]
    public class MainActivity : Activity {
        GLMainView view;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Create our OpenGL view, and display it
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

