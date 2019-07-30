using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using FFImageLoading.Forms.Platform;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace EssentialUIKit.Droid
{
    [Activity(Label = "Essential UI Kit", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {   
            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Syncfusion.XForms.Android.Core.Core.Init(this);

            // FFImageLoading library
            CachedImageRenderer.Init(true);

            this.LoadApplication(new App());

            // Change the status bar color
            this.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0, 0));

            // Enable scrolling to the page when the keyboard is enabled
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }
    }
}