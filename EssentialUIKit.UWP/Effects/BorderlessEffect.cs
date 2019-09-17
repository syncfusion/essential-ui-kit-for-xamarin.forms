using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Setter = Windows.UI.Xaml.Setter;
using Style = Windows.UI.Xaml.Style;

[assembly: ResolutionGroupName("EssentialUIKit")]
[assembly: ExportEffect(typeof(EssentialUIKit.UWP.Effects.BorderlessEffect), nameof(EssentialUIKit.UWP.Effects.BorderlessEffect))]

namespace EssentialUIKit.UWP.Effects
{
    public class BorderlessEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            FormsTextBox formsTextBox = this.Control as FormsTextBox;
            if (formsTextBox != null)
            {
                formsTextBox.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                formsTextBox.VerticalAlignment = VerticalAlignment.Center;

                // Make the text vertically aligned at centre of the entry.
                Style style = new Style(typeof(Windows.UI.Xaml.Controls.ContentControl));
                style.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center));
                this.Control.Resources.Add(typeof(Windows.UI.Xaml.Controls.ContentControl), style);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
