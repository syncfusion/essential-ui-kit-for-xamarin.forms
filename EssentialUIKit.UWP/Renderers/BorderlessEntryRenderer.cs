using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Setter = Windows.UI.Xaml.Setter;
using Style = Windows.UI.Xaml.Style;

[assembly: ExportRenderer(typeof(EssentialUIKit.Controls.BorderlessEntry), typeof(EssentialUIKit.UWP.BorderlessEntryRenderer))]

namespace EssentialUIKit.UWP
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                this.Control.VerticalAlignment = VerticalAlignment.Center;

                // Make the text vertically aligned at centre of the entry.
                Style style = new Style(typeof(Windows.UI.Xaml.Controls.ContentControl));
                style.Setters.Add(new Setter(VerticalAlignmentProperty, VerticalAlignment.Center));                
                this.Control.Resources.Add(typeof(Windows.UI.Xaml.Controls.ContentControl), style);
            }
        }
    }
}
