using System;
using System.Globalization;
using Xamarin.Forms;

namespace MoviesApp.Converters
{
    public class ImageFilePathToImageUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imagePath = value as string;
            return $"https://image.tmdb.org/t/p/w500{imagePath}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
