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
        /// Animate a double of an UIElement with a specified time.
        /// </summary>
        /// <param name="uiElement">UIElement that contains the double.</param>
        /// <param name="doubleProperty">Double property to animate.</param>
        /// <param name="to">New value of the double.</param>
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
        /// Animate a brush of an UIElement with a specified time.
        /// </summary>
        /// <remarks>
        /// Note: If the initial brush (from) or the final brush (to) are null, no animation will be executed.
        /// </remarks>
        /// <param name="uiElement">UIElement that contains the brush.</param>
        /// <param name="brushProperty">Brush property to animate.</param>
        /// <param name="to">New value of the brush.</param>
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
