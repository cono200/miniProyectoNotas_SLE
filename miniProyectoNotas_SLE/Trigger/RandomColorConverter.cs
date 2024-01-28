using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace miniProyectoNotas_SLE.Trigger
{
    public class RandomColorConverter : IValueConverter
    {
        private static readonly Random random = new Random();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
