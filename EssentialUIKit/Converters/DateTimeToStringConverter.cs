using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// Converts the date-time to string for grouping message by date.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DateTimeToStringConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the date-time to string.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var currentTime = DateTime.Now;
            var dateTime = (DateTime)value;

            if (dateTime.Day == currentTime.Day)
            {
                return "Today";
            }

            return dateTime.Day == currentTime.AddDays(-1).Day ? "Yesterday" : dateTime.ToString("MMMM dd, yyyy", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// This method is used to convert the date-time to string.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns null.</returns>  
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}