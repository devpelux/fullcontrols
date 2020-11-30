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
        /// Animate a brush from a dependency object with a specified time.
        /// </summary>
        /// <param name="dependencyObject">Dependency object that contains the brush.</param>
        /// <param name="brushProperty">Brush dependency property to animate.</param>
        /// <param name="to">New value of the brush.</param>
        /// <param name="animationTime">Animation time.</param>
        internal static void AnimateBrush(DependencyObject dependencyObject, DependencyProperty brushProperty, Brush to, TimeSpan animationTime)
        {
            if (animationTime > TimeSpan.Zero)
            {
                Brush from = GetUnfreezedBrush(dependencyObject, brushProperty);

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
                    dependencyObject.SetValue(brushProperty, to);
                }
            }
            else
            {
                dependencyObject.SetValue(brushProperty, to);
            }
        }

        /// <summary>
        /// Unfreeze the brush obtained from a dependency property of a dependency object and returns the brush.
        /// </summary>
        /// <param name="dependencyObject">Dependency object that contains the brush.</param>
        /// <param name="brushProperty">Brush dependency property.</param>
        /// <returns>Unfreezed copy of the brush.</returns>
        private static Brush GetUnfreezedBrush(DependencyObject dependencyObject, DependencyProperty brushProperty)
        {
            dependencyObject.SetValue(brushProperty, ((Brush)dependencyObject.GetValue(brushProperty)).CloneCurrentValue());
            return (Brush)dependencyObject.GetValue(brushProperty);
        }
    }
}
