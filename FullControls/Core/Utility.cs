using FullControls.Extra;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FullControls.Core
{
    /// <summary>
    /// Some utility methods.
    /// </summary>
    internal static class Utility
    {
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
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = from,
                    To = to,
                    Duration = new Duration(animationTime)
                };
                uiElement.BeginAnimation(doubleProperty, animation);
            }
            else
            {
                uiElement.SetValue(doubleProperty, to);
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
        internal static void AnimateBrush(UIElement uiElement, DependencyProperty brushProperty, Brush to, TimeSpan animationTime)
        {
            if (animationTime > TimeSpan.Zero && !uiElement.IsNull(brushProperty) && to != null)
            {
                uiElement.SetValue(brushProperty, ((Brush)uiElement.GetValue(brushProperty)).CloneCurrentValue()); //Unfreeze the brush
                Brush from = (Brush)uiElement.GetValue(brushProperty);

                if (from is SolidColorBrush sbFrom && to is SolidColorBrush sbTo)
                {
                    ColorAnimation animation = new ColorAnimation
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
    }
}
