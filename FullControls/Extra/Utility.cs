using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FullControls.Extra
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
            Brush from = GetUnfreezedBrush(dependencyObject, brushProperty);
            AnimationTimeline animation = CreateAnimation(from, to, animationTime);

            if (animation is ColorAnimation)
            {
                from.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            }
            else if (animation is ObjectAnimationUsingKeyFrames)
            {
                ((UIElement)dependencyObject).BeginAnimation(brushProperty, animation);
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

        /// <summary>
        /// Create an animation from a brush to another with specified time.
        /// </summary>
        /// <param name="from">Initial brush.</param>
        /// <param name="to">End brush.</param>
        /// <param name="animationTime">Animation time.</param>
        /// <returns>AnimationTimeline.</returns>
        private static AnimationTimeline CreateAnimation(Brush from, Brush to, TimeSpan animationTime)
        {
            if (from is SolidColorBrush sbFrom && to is SolidColorBrush sbTo)
            {
                return new ColorAnimation
                {
                    From = sbFrom.Color,
                    To = sbTo.Color,
                    Duration = new Duration(animationTime)
                };
            }
            else
            {
                return new ObjectAnimationUsingKeyFrames
                {
                    KeyFrames = new ObjectKeyFrameCollection
                    {
                        new DiscreteObjectKeyFrame(to, KeyTime.FromTimeSpan(new TimeSpan(0)))
                    },
                    Duration = new Duration(new TimeSpan(0))
                };
            }
        }
    }
}
