using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the Boolean values to string.     
    /// </summary>
    [Preserve(AllMembers = true)]
    public class BooleanToStringConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the bool to string.
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
                if (parameter.ToString() == "0")
                {
                    if ((bool)value)
                    {
                        return "\ue72f";
                    }
                    else
                    {
                        return "\ue734";
                    }
                }
                else if (parameter.ToString() == "1")
                {
                    if ((bool)value)
                    {
                        return "\ue732";
                    }
                    else
                    {
                        return "\ue701";
                    }
                }
                else if (parameter.ToString() == "2")
                {
                    if ((bool)value)
                    {
                        return "+";
                    }
                    else
                    {
                        return "-";
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// This method is used to convert the string to bool.
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
