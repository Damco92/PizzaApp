using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PizzaApp.WPF.Helpers
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch (value)
                {
                    case "Capri":
                        return new BitmapImage(new Uri(@"C:\Users\d.stojanov\Desktop\Pizzas-Images\capri.png", UriKind.Relative));
                    case "Funghi":
                        return new BitmapImage(new Uri(@"C:\Users\d.stojanov\Desktop\Pizzas-Images\funghi.png", UriKind.Relative));
                }
            }
            return new BitmapImage(new Uri(@"C:\Users\d.stojanov\Desktop\Pizzas-Images\peperoni.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
