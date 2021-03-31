using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the string to CVV mask.     
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CVVToMaskCodeConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the string to CVV mask.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                if (value.ToString().Length == 1)
                {
                    return "X";
                }
                else if (value.ToString().Length == 2)
                {
                    return "XX";
                }
                else if (value.ToString().Length == 3)
                {
                    return "XXX";
                }
                else if (value.ToString().Length == 4)
                {
                    return "XXXX";
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// This method is used to convert the CVV mask to string.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
