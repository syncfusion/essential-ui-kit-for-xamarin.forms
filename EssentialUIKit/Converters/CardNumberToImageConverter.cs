using System;
using System.Globalization;
using Xamarin.Forms;

namespace EssentialUIKit.Converters
{
    public class CardNumberToImageConverter : CardValidator, IValueConverter
    {
        public ImageSource NotRecognized { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var number = value.ToString();
                var numberNormalized = number.Replace("-", string.Empty);

                if (VisaRegex.IsMatch(numberNormalized))
                {
                    return "Visa.png";
                }

                if (MasterRegex.IsMatch(numberNormalized))
                {
                    return "Card.png";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
