using Android.Content;
using EssentialUIKit.AppLayout.Controls;
using EssentialUIKit.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ParallaxListView), typeof(ParallaxListViewRenderer))]

namespace EssentialUIKit.Droid
{
    public class ParallaxListViewRenderer : ListViewRenderer
    {
        private int previousScrollPosition;

        public ParallaxListViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                (e.NewElement as ParallaxListView).WidthInPixel = Context.Resources.DisplayMetrics.WidthPixels;
                if (this.Control != null)
                {
                    this.Control.Scroll += (sender, arg) =>
                    {
                        var topView = arg.View.GetChildAt(0);
                        if (this.Control.FirstVisiblePosition == 0)
                        {
                            previousScrollPosition = topView.Top;
                        }

                        ParallaxListView.OnScrollChanged(Element, new ScrollChangedEventArgs(previousScrollPosition));
                    };
                }
            }
        }
    }
}