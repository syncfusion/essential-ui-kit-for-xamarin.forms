using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the int to date format value. 
    /// </summary>
    [Preserve(AllMembers = true)]
    public class IntToDateFormatConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the int to date format value.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the date format value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                case 1:
                    {
                        return "dd-MMM";
                    }
                case 2:
                case 3:
                case 4:
                    {
                        return "MMM";
                    }

            }

            return "MMM";
        }

        /// <summary>
        /// This method is used to convert the date format to int.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the int.</returns>     
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }

    }
}
