using Android.Content;
using Android.Support.V4.App;
using EssentialUIKit.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(TransitionNavigationPageRenderer))]

namespace EssentialUIKit.Droid.Renderers
{
    public class TransitionNavigationPageRenderer : NavigationPageRenderer
    {
        public TransitionNavigationPageRenderer(Context context)
            : base(context)
        {
        }

        protected override void SetupPageTransition(FragmentTransaction transaction, bool isPush)
        {
            if (transaction != null)
            {
                if (isPush)
                {
                    transaction.SetCustomAnimations(Resource.Animation.abc_slide_in_bottom, 0, 0, 0);
                }
                else
                {
                    transaction.SetCustomAnimations(0, Resource.Animation.abc_slide_out_bottom, 0, 0);
                }

                base.SetupPageTransition(transaction, isPush);
            }
        }
    }
}