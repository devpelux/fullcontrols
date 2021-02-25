using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace FullControls.Extra
{
    /// <summary>
    /// <para>Used to clip elements that are out of a control.</para>
    /// <para>You can specify <c>CornerRadius</c> and <c>BorderThickness</c> if the control has these properties.</para>
    /// <remarks>Are supported only uniform <c>CornerRadius</c> and <c>BorderThickness</c>.</remarks>
    /// </summary>
    public class ClipConverter : IMultiValueConverter
    {
        /// <summary>
        /// <para>Calculates and returns a clip with the specified parameters.</para>
        /// </summary>
        /// <param name="values">
        /// <para><b>Mandatory arguments:</b> <c>Width</c> (<paramref name="values"/>[0]), <c>Height</c> (<paramref name="values"/>[1]).</para>
        /// <para><b>Optional arguments:</b> <c>CornerRadius</c> (<paramref name="values"/>[2]), <c>BorderThickness</c> (<paramref name="values"/>[3]).</para>
        /// <remarks>Are supported only uniform CornerRadius and BorderThickness.</remarks>
        /// </param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>RectangleGeometry clip.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                if (values[0] is double width && values[1] is double height)
                {
                    if (width < double.Epsilon || height < double.Epsilon) return Geometry.Empty;
                    RectangleGeometry clip = new RectangleGeometry(new Rect(0, 0, width, height));
                    clip.Freeze();
                    return clip;
                }
                else throw new ArgumentException("Invalid arguments! Must be: double, double, [CornerRadius], [Thickness].");
            }
            else if (values.Length == 3)
            {
                if (values[0] is double width && values[1] is double height && values[2] is CornerRadius radius)
                {
                    if (width < double.Epsilon || height < double.Epsilon) return Geometry.Empty;
                    RectangleGeometry clip = new RectangleGeometry(new Rect(0, 0, width, height), radius.TopLeft, radius.TopLeft);
                    clip.Freeze();
                    return clip;
                }
                else throw new ArgumentException("Invalid arguments! Must be: double, double, [CornerRadius], [Thickness].");
            }
            else if (values.Length == 4)
            {
                if (values[0] is double width && values[1] is double height && values[2] is CornerRadius radius && values[3] is Thickness thickness)
                {
                    if (width < double.Epsilon || height < double.Epsilon) return Geometry.Empty;
                    RectangleGeometry clip = new RectangleGeometry(new Rect(0, 0, width, height), radius.TopLeft - (thickness.Left / 2), radius.TopLeft - (thickness.Left / 2));
                    clip.Freeze();
                    return clip;
                }
                else throw new ArgumentException("Invalid arguments! Must be: double, double, [CornerRadius], [Thickness].");
            }
            else throw new ArgumentException("Invalid arguments! Must be: double, double, [CornerRadius], [Thickness].");
        }

        /// <summary>
        /// Unsupported.
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
