using Android.Content;
using Android.Widget;
using EssentialUIKit.AppLayout.Controls;
using EssentialUIKit.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TemplateHostView), typeof(TemplateHostViewRenderer))]

namespace EssentialUIKit.Droid.Renderers
{
    public class TemplateHostViewRenderer : ViewRenderer
    {
        public TemplateHostViewRenderer(Context context) : base(context)
        {
        }

        internal IVisualElementRenderer GetNativeView(Page formsView, TemplateHostView parent)
        {
            if (formsView == null)
            {
                return null;
            }

            var renderer = Platform.GetRenderer(formsView);

            if (renderer == null)
            {
                renderer = Platform.CreateRendererWithContext(formsView, this.Context);
                Platform.SetRenderer(formsView, renderer);
            }

            formsView.Parent = GetPage(parent);

            formsView.Layout(new Rectangle(0, 0, 1, 1));

            return renderer;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Control != null && this.Control.Handle != System.IntPtr.Zero)
            {
                var supportFragmentManager = (this.Control.Context as Android.Support.V4.App.FragmentActivity).SupportFragmentManager;
                supportFragmentManager?.BeginTransaction().Remove(supportFragmentManager.Fragments[supportFragmentManager.Fragments.Count - 1]).Commit();

                this.Control?.RemoveFromParent();
            }

            base.Dispose(disposing);
            ////TODO: Dispose the elements.
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            var pageView = e.NewElement as TemplateHostView;

            var nativePage = this.GetNativeView(pageView?.Template, pageView);

            if (nativePage != null)
            {
                this.SetNativeControl(nativePage.View);
            }
            else
            {
                this.SetNativeControl(new TextView(this.Context) { Text = "There is no loaded page" });
            }
        }

        private static Page GetPage(VisualElement element)
        {
            while (true)
            {
                if (element is Page)
                {
                    return (Page)element;
                }

                element = element.Parent as VisualElement;
            }
        }
    }
}