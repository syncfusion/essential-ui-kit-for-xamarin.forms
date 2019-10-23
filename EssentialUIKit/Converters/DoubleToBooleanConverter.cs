using Syncfusion.SfChart.XForms;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;

namespace EssentialUIKit.Converters
{
    public class DoubleToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (value as ObservableCollection<ChartDataPoint>).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
