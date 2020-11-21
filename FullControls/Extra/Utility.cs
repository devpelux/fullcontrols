using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FullControls.Extra
{
    internal static class Utility
    {
        internal static Brush GetUnfreezedBrush(DependencyObject dependencyObject, DependencyProperty brushProperty)
        {
            dependencyObject.SetValue(brushProperty, ((Brush)dependencyObject.GetValue(brushProperty)).CloneCurrentValue());
            return (Brush)dependencyObject.GetValue(brushProperty);
        }

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

        internal static AnimationTimeline CreateAnimation(Brush from, Brush to, TimeSpan animationTime)
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
