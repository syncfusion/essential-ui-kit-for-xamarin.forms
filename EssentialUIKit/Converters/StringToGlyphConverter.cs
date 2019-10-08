using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the string to font icon text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class StringToGlyphConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the string to font icon text.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value;
            switch ((string)text)
            {
                case "Text":
                    ((Label)parameter).IsVisible = false;
                    return text;
                case "Viewed":
                case "New":
                    Application.Current.Resources.TryGetValue("PrimaryColor", out var retVal);
                    ((Label)parameter).TextColor = (Color)retVal;
                    break;
                case "Received":
                case "Sent":
                    Application.Current.Resources.TryGetValue("Gray-600", out var colorVal);
                    ((Label)parameter).TextColor = (Color)colorVal;
                    break;
                case "Audio":
                case "Video":
                case "Contact":
                case "Photo":
                    ((Label)parameter).IsVisible = true;
                    break;
            }

            ((Label)parameter).Resources.TryGetValue((string)value, out text);
            return text;
        }

        /// <summary>
        /// This method is used to convert the string to font icon text.
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