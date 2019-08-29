using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the integer values to thickness.     
    /// </summary>
    [Preserve(AllMembers = true)]
    public class IntToThicknessConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the integer to thickness.
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the targetType</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>Thickness</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var margin = new Thickness(0);
            if (value != null)
            {
                int itemCount;
                int.TryParse(value.ToString(), out itemCount);
                if (itemCount >= 0)
                    return margin = new Thickness(0, -15, 0, 0);
            }
            return margin;
        }

        /// <summary>
        /// This method is used to convert the thickness to integer.
        /// </summary>
        /// <param name="value">Gets the value</param>
        /// <param name="targetType">Gets the targetType</param>
        /// <param name="parameter">Gets the parameter</param>
        /// <param name="culture">Gets the culture</param>
        /// <returns>true</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
