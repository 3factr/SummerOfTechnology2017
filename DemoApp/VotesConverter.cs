using System;
using System.Globalization;
using Xamarin.Forms;
namespace DemoApp
{
    public class VotesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var intVal = System.Convert.ToInt32(value);
            return intVal + " stem" + (intVal != 1 ? "men" : "");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
