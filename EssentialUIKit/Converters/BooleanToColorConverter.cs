using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the Boolean values to color objects. 
    /// This is needed to validate in the Entry controls. If the validation is failed, it will return the color code of error, otherwise it will be transparent.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class BooleanToColorConverter : IValueConverter
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

            switch (parameter.ToString())
            {
                case "0" when (bool) value:
                    return Color.FromRgba(255, 255, 255, 0.6);
                case "1" when (bool) value:
                    return Color.FromHex("#FF4A4A");
                case "2" when (bool) value:
                    return Color.FromHex("#FF4A4A");
                case "2":
                    return Color.FromHex("#ced2d9");
                case "3" when (bool) value:
                    return Color.FromHex("#959eac");
                case "3":
                    return Color.FromHex("#ced2d9");
                case "4" when (bool) value:
                    Application.Current.Resources.TryGetValue("PrimaryColor", out var retVal);
                    return (Color) retVal;
                case "4":
                    Application.Current.Resources.TryGetValue("Gray-600", out var outVal);
                    return (Color) outVal;
                case "5" when (bool)value:
                    Application.Current.Resources.TryGetValue("Green", out var retGreen);
                    return (Color)retGreen;
                case "5":
                    Application.Current.Resources.TryGetValue("Red", out var retRed);
                    return (Color)retRed;
                case "6" when (bool)value:
                    Application.Current.Resources.TryGetValue("Gray-300", out var gray300);
                    return (Color)gray300;
                case "6":
                    Application.Current.Resources.TryGetValue("Secondary", out var secondary);
                    return (Color)secondary;
                case "7" when !(bool)value:
                    Application.Current.Resources.TryGetValue("Gray-100", out var gray100);
                    return (Color)gray100;
                case "8" when (bool)value:
                    Application.Current.Resources.TryGetValue("PrimaryColor", out var primary);
                    return (Color)primary;
                case "8":
                    Application.Current.Resources.TryGetValue("Gray-White", out var graywhite);
                    return (Color)graywhite;
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