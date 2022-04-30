using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using WpfCoreTools;
using WpfCoreTools.Extensions;

namespace FullControls.Core
{
    /// <summary>
    /// Some utility methods and values.
    /// </summary>
    internal static class Util
    {
        /// <summary>
        /// <see cref="SolidColorBrush"/> with value of <c>#00FFFFFF</c>.
        /// </summary>
        internal static SolidColorBrush WhiteTransparentBrush { get; } = new(Color.FromArgb(0, 255, 255, 255));

        /// <summary>
        /// <see cref="SolidColorBrush"/> with value of <c>#00000000</c>.
        /// </summary>
        internal static SolidColorBrush BlackTransparentBrush { get; } = new(Color.FromArgb(0, 0, 0, 0));

        /// <summary>
        /// Animate a <see cref="double"/> of an <see cref="UIElement"/> with a specified time.
        /// </summary>
        /// <param name="uiElement"><see cref="UIElement"/> that contains the <see cref="double"/>.</param>
        /// <param name="doubleProperty"><see cref="double"/> property to animate.</param>
        /// <param name="to">New value of the <see cref="double"/>.</param>
        /// <param name="animationTime">Animation time.</param>
        internal static void AnimateDouble(UIElement uiElement, DependencyProperty doubleProperty, double to, TimeSpan animationTime)
        {
            if (animationTime > TimeSpan.Zero)
            {
                double from = (double)uiElement.GetValue(doubleProperty);
                DoubleAnimation animation = new()
                {
                    From = from,
                    To = to,
                    Duration = new Duration(animationTime)
                };
                uiElement.BeginAnimation(doubleProperty, animation);
            }
            else
            {
                uiElement.SetCurrentValue(doubleProperty, to);
            }
        }

        /// <summary>
        /// Animate a <see cref="Brush"/> of an <see cref="UIElement"/> with a specified time.
        /// </summary>
        /// <remarks>
        /// Note: If the initial <see cref="Brush"/> (from) or the final <see cref="Brush"/> (to) are <see langword="null"/>, no animation will be executed.
        /// </remarks>
        /// <param name="uiElement"><see cref="UIElement"/> that contains the <see cref="Brush"/>.</param>
        /// <param name="brushProperty"><see cref="Brush"/> property to animate.</param>
        /// <param name="to">New value of the <see cref="Brush"/>.</param>
        /// <param name="animationTime">Animation time.</param>
        internal static void AnimateBrush(UIElement uiElement, DependencyProperty brushProperty, Brush? to, TimeSpan animationTime)
        {
            if (animationTime > TimeSpan.Zero && !uiElement.IsNull(brushProperty) && to != null)
            {
                uiElement.SetValue(brushProperty, ((Brush)uiElement.GetValue(brushProperty)).CloneCurrentValue()); //Unfreeze the brush
                Brush from = (Brush)uiElement.GetValue(brushProperty);

                if (from is SolidColorBrush sbFrom && to is SolidColorBrush sbTo)
                {
                    ColorAnimation animation = new()
                    {
                        From = sbFrom.Color,
                        To = sbTo.Color,
                        Duration = new Duration(animationTime)
                    };
                    from.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                }
                else
                {
                    uiElement.SetValue(brushProperty, to);
                }
            }
            else
            {
                uiElement.SetValue(brushProperty, to);
            }
        }

        /// <summary>
        /// Generates a <see cref="DoubleAnimation"/> ready to be added to a <see cref="Storyboard"/> with the specified parameters.
        /// </summary>
        /// <param name="from">Starting value.</param>
        /// <param name="to">Ending value.</param>
        /// <param name="duration">Animation duration.</param>
        /// <param name="targetObject">Target object of the animation.</param>
        /// <param name="targetProperty">Target property to animate.</param>
        /// <returns><see cref="DoubleAnimation"/> ready to be added to a <see cref="Storyboard"/>.</returns>
        internal static DoubleAnimation GenerateDoubleAnimation(double from, double to, TimeSpan duration, DependencyObject targetObject, PropertyPath targetProperty)
        {
            DoubleAnimation doubleAnimation = new(from, to, new Duration(duration));
            Storyboard.SetTarget(doubleAnimation, targetObject);
            Storyboard.SetTargetProperty(doubleAnimation, targetProperty);
            return doubleAnimation;
        }

        /// <summary>
        /// Retrieves the keyboard repeat-delay setting, which is a value in the range from 0
        /// (approximately 250 ms delay) through 3 (approximately 1 second delay).
        /// The actual delay associated with each value may vary depending on the hardware.
        /// </summary>
        /// <returns>The keyboard repeat-delay.</returns>
        internal static int GetKeyboardDelay()
        {
            int delay = SystemParameters.KeyboardDelay;
            // SPI_GETKEYBOARDDELAY 0,1,2,3 correspond to 250,500,750,1000ms
            if (delay < 0 || delay > 3)
                delay = 0;
            return (delay + 1) * 250;
        }

        /// <summary>
        /// Retrieves the keyboard repeat-speed setting, which is a value in the range from 0
        /// (approximately 2.5 repetitions per second) through 31 (approximately 30 repetitions per second).
        /// The actual repeat rates are hardware-dependent and may vary from a linear scale by as much as 20%.
        /// </summary>
        /// <returns>The keyboard repeat-speed.</returns>
        internal static int GetKeyboardSpeed()
        {
            int speed = SystemParameters.KeyboardSpeed;
            // SPI_GETKEYBOARDSPEED 0,...,31 correspond to 1000/2.5=400,...,1000/30 ms
            if (speed < 0 || speed > 31)
                speed = 31;
            return (31 - speed) * (400 - 1000 / 30) / 31 + 1000 / 30;
        }

        /// <summary>
        /// Check if a width or height value is valid.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><see langword="true"/> if the value is valid, <see langword="false"/> otherwise.</returns>
        internal static bool IsWidthHeightValid(object value)
        {
            double v = (double)value;
            return (double.IsNaN(v)) || (v >= 0.0d && !double.IsPositiveInfinity(v));
        }

        /// <summary>
        /// Check if a min width or min height value is valid.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><see langword="true"/> if the value is valid, <see langword="false"/> otherwise.</returns>
        internal static bool IsMinWidthHeightValid(object value)
        {
            double v = (double)value;
            return (!double.IsNaN(v) && v >= 0.0d && !double.IsPositiveInfinity(v));
        }

        /// <summary>
        /// Check if a max width or max height value is valid.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns><see langword="true"/> if the value is valid, <see langword="false"/> otherwise.</returns>
        internal static bool IsMaxWidthHeightValid(object value)
        {
            double v = (double)value;
            return (!double.IsNaN(v) && v >= 0.0d);
        }

        /// <summary>
        /// Calculates the value to be used for layout rounding at high DPI.
        /// </summary>
        /// <param name="value">Input value to be rounded.</param>
        /// <param name="dpiScale">Ratio of screen's DPI to layout DPI</param>
        /// <returns>Adjusted value that will produce layout rounding on screen at high dpi.</returns>
        /// <remarks>This is a layout helper method. It takes DPI into account and also does not return
        /// the rounded value if it is unacceptable for layout, e.g. Infinity or NaN. It's a helper associated with
        /// UseLayoutRounding  property and should not be used as a general rounding utility.</remarks>
        internal static double RoundLayoutValue(double value, double dpiScale)
        {
            double newValue;

            // If DPI == 1, don't use DPI-aware rounding.
            if (!MathUtils.AreClose(dpiScale, 1.0))
            {
                newValue = Math.Round(value * dpiScale) / dpiScale;
                // If rounding produces a value unacceptable to layout (NaN, Infinity or MaxValue), use the original value.
                if (double.IsNaN(newValue) || double.IsInfinity(newValue) || MathUtils.AreClose(newValue, double.MaxValue))
                {
                    newValue = value;
                }
            }
            else
            {
                newValue = Math.Round(value);
            }

            return newValue;
        }

        /// <summary>
        /// Rounds the <see cref="Thickness"/> with the specified <see cref="DpiScale"/>.
        /// </summary>
        internal static Thickness RoundThickness(Thickness thickness, DpiScale dpi)
        {
            return new Thickness(RoundLayoutValue(thickness.Left, dpi.DpiScaleX),
                                 RoundLayoutValue(thickness.Top, dpi.DpiScaleY),
                                 RoundLayoutValue(thickness.Right, dpi.DpiScaleX),
                                 RoundLayoutValue(thickness.Bottom, dpi.DpiScaleY));
        }

        /// <summary>
        /// Adapt a value from a range to a new range (both starting from 0).
        /// </summary>
        /// <param name="val">Value to adapt to the new range.</param>
        /// <param name="valRange">Old range of <paramref name="val"/>.</param>
        /// <param name="newRange">New range of <paramref name="val"/>.</param>
        /// <returns><paramref name="val"/> divided by <paramref name="valRange"/> and multiplied by <paramref name="newRange"/>.</returns>
        internal static double Adapt(double val, double valRange, double newRange) => val / valRange * newRange;

        /// <summary>
        /// Returns the maximum between 4 doubles.
        /// </summary>
        internal static double Max(double d1, double d2, double d3, double d4) => Math.Max(Math.Max(Math.Max(d1, d2), d3), d4);
    }
}
