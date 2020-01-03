using EssentialUIKit.AppLayout.Controls;
using EssentialUIKit.UWP;
using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(TemplateHostView), typeof(TemplateHostViewRenderer))]

namespace EssentialUIKit.UWP
{
    /// <summary>
    /// Implementation of TemplateHostViewRenderer.
    /// </summary>
    public class TemplateHostViewRenderer : ViewRenderer<TemplateHostView, FrameworkElement>
    {
        /// <summary>
        /// Added the view in TemplateHostPage.
        /// </summary>
        /// <param name="e">The editor</param>
        protected override void OnElementChanged(ElementChangedEventArgs<TemplateHostView> e)
        {
            base.OnElementChanged(e);
            var pageView = e.NewElement as TemplateHostView;

            if (pageView != null)
            {
                IVisualElementRenderer renderer = pageView?.Template.GetOrCreateRenderer();

                FrameworkElement native = renderer.ContainerElement as FrameworkElement;
                var size = pageView.Measure(double.PositiveInfinity, double.PositiveInfinity);
                pageView?.Template.Layout(new Rectangle(0, 0, size.Request.Width, size.Request.Height));

                this.SetNativeControl(native);
            }
        }
    }
}
