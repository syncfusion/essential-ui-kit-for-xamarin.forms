using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the DynamicResource to color objects. 
    /// This is needed when DynamicResource is set based on idiom/platform.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class DynamicResourceToColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the DynamicResource to color.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the color.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DynamicResource dynamicResource))
            {
                return value;
            }

            Application.Current.Resources.TryGetValue(dynamicResource.Key, out var color);
            return (Color) color;
        }

        /// <summary>
        /// This method is used to convert the color to DynamicResource.
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