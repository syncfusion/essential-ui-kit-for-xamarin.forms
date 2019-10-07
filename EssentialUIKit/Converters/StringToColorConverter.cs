using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the Boolean values to color objects. 
    /// </summary>
    [Preserve(AllMembers = true)]
    public class StringToColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the bool to color.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the color.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return Color.Default;
            }

            if (value == null)
            {
                return Color.Default;
            }

            switch (parameter.ToString())
            {
                case "0":
                    {
                        if ((string)value == "Dispatched")
                        {
                            Application.Current.Resources.TryGetValue("Blue", out var retBlue);
                            return retBlue;
                        }
                        else if ((string)value == "Cancelled")
                        {
                            Application.Current.Resources.TryGetValue("Red", out var retRed);
                            return retRed;
                        }
                        else
                        {
                            Application.Current.Resources.TryGetValue("Green", out var retGreen);
                            return retGreen;
                        }
                    }

                default:
                    return Color.Transparent;
            }
        }

        /// <summary>
        /// This method is used to convert the color to bool.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>      
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
