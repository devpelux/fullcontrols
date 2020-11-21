using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace FullControls.Extra
{
    /// <summary>
    /// Permette di nascondere gli elementi fuori dal bordo di un controllo.
    /// Supporta CornerRadius e Thickness omogenei.
    /// </summary>
    public class ClipConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 4 && values[0] is double width && values[1] is double height && values[2] is Thickness thickness && values[3] is CornerRadius radius)
            {
                if (width < double.Epsilon || height < double.Epsilon) return Geometry.Empty;
                RectangleGeometry clip = new RectangleGeometry(new Rect(0, 0, width, height), radius.TopLeft - (thickness.Left / 2), radius.TopLeft - (thickness.Left / 2));
                clip.Freeze();
                return clip;
            }
            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
