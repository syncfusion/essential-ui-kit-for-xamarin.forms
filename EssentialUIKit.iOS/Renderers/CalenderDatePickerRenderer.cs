using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EssentialUIKit.Controls.CalenderDatePicker), typeof(EssentialUIKit.iOS.CalenderDatePickerRenderer))]

namespace EssentialUIKit.iOS
{
    /// <summary>
    /// Implementation of Calender Data picker control.
    /// </summary>
    public class CalenderDatePickerRenderer : DatePickerRenderer
    {
        /// <summary>
        /// Used to customize the date picker control.
        /// </summary>
        /// <param name="e">The DatePicker</param>
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Text = (e.NewElement as Controls.CalenderDatePicker).PlaceHolderText;
                this.Control.TextColor = new UIColor(96 / 255, 106 / 255, 123 / 255, 1.0f);
                this.Control.BorderStyle = UITextBorderStyle.None;
                this.Control.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            }
        }
    }
}