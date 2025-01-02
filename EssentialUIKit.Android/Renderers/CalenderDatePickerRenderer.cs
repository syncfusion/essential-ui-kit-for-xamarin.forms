using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EssentialUIKit.Controls.CalenderDatePicker), typeof(EssentialUIKit.Droid.CalenderDatePickerRenderer))]

namespace EssentialUIKit.Droid
{
    /// <summary>
    /// Implementation of Calender Data picker control.
    /// </summary>
    public class CalenderDatePickerRenderer : DatePickerRenderer
    {
        public CalenderDatePickerRenderer(Context context) : base(context)
        {
        }

        /// <summary>
        /// Used to customize the date picker control.
        /// </summary>
        /// <param name="e">The DatePicker</param>
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.SetBackground(null);
                Control.Text = (e.NewElement as Controls.CalenderDatePicker).PlaceHolderText;
                Control.SetTextColor(new Android.Graphics.Color(96, 106, 123));
                Control.Gravity = Android.Views.GravityFlags.CenterVertical;
                Control.SetPadding(0, 0, 0, 0);
            }
        }
    }
}