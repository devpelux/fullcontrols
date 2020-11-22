using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace FullControls.Extra
{
    /// <summary>
    /// <para>Used to clip elements that are out of a control.</para>
    /// <para>Supports only CornerRadius and Thickness that are equals for every side.</para>
    /// </summary>
    public class ClipConverter : IMultiValueConverter
    {
        /// <summary>
        /// <para>Returns a clip with defined parameters.</para>
        /// <para>Requested 4 params (in values): width (double), height (double), border thickness (Thickness), corner radius (CornerRadius).</para>
        /// </summary>
        /// <param name="values">Requested 4 params: width (double), height (double), border thickness (Thickness), corner radius (CornerRadius).</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>RectangleGeometry clip.</returns>
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

        /// <summary>
        /// Unsupported.
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
