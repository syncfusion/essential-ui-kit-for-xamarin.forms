using System;
using System.Globalization;
using Xamarin.Forms;

namespace EssentialUIKit.Converters
{
    public class CardNumberToColorConverter : CardValidator, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null && parameter != null)
            {
                {
                    if (parameter.ToString() == "0")
                    {
                        return "#d54381";
                    }

                    if (parameter.ToString() == "1")
                    {
                        return "#7644ad";
                    }
                }
            }

            var number = value?.ToString();
            var numberNormalized = number.Replace("-", string.Empty);

            if (parameter != null)
            {
                if (VisaRegex.IsMatch(numberNormalized))
                {
                    if (parameter.ToString() == "0")
                    {
                        return "#af4aff";
                    }

                    if (parameter.ToString() == "1")
                    {
                        return "#3e5aff";
                    }
                }
                else if (MasterRegex.IsMatch(numberNormalized))
                {
                    if (parameter.ToString() == "0")
                    {
                        return "#713d74";
                    }

                    if (parameter.ToString() == "1")
                    {
                        return "#221e60";
                    }
                }
                else
                {
                    if (parameter.ToString() == "0")
                    {
                        return "#d54381";
                    }

                    if (parameter.ToString() == "1")
                    {
                        return "#7644ad";
                    }
                }
            }

            return Color.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
