using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(EssentialUIKit.Controls.CalenderDatePicker), typeof(EssentialUIKit.UWP.CalenderDatePickerRenderer))]

namespace EssentialUIKit.UWP
{
    /// <summary>
    /// Implementation of Calender Data picker control.
    /// </summary>
    public class CalenderDatePickerRenderer : ViewRenderer<DatePicker, Windows.UI.Xaml.Controls.CalendarDatePicker>
    {
        /// <summary>
        /// Used to customize the date picker control.
        /// </summary>
        /// <param name="e">The DatePicker</param>
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null && e.NewElement != null)
            {
                Windows.UI.Xaml.Controls.CalendarDatePicker datePicker = new Windows.UI.Xaml.Controls.CalendarDatePicker();
                datePicker.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                this.SetNativeControl(datePicker);
            }
        }
    }
}
