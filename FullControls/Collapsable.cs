using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FullControls
{
    /// <summary>
    /// Adds collapsing and expanding functionality to another element.
    /// </summary>
    public class Collapsable : Decorator
    {
        private bool loaded = false;
        private bool isAnimating = false;
        private Size preCollapsingSize;

        /// <summary>
        /// Specifies if the <see cref="Collapsable"/> is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        /// <remarks>If <see cref="IsAnimating"/> is <see langword="true"/> the value is reverted to the previous value.</remarks>
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="IsExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(Collapsable),
                new PropertyMetadata(true, new PropertyChangedCallback((d, e) => ((Collapsable)d).OnExpandedChanged((bool)e.NewValue)),
                    new CoerceValueCallback((d, o) => ((Collapsable)d).IsAnimating ? d.GetValue(IsExpandedProperty) : o)));

        /// <summary>
        /// Specifies if to enable the <see cref="FrameworkElement.Height"/> animation.
        /// </summary>
        public bool HeightAnimation
        {
            get => (bool)GetValue(HeightAnimationProperty);
            set => SetValue(HeightAnimationProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="HeightAnimation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeightAnimationProperty =
            DependencyProperty.Register(nameof(HeightAnimation), typeof(bool), typeof(Collapsable), new PropertyMetadata(true));

        /// <summary>
        /// Specifies if to enable the <see cref="FrameworkElement.Width"/> animation.
        /// </summary>
        public bool WidthAnimation
        {
            get => (bool)GetValue(WidthAnimationProperty);
            set => SetValue(WidthAnimationProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="WidthAnimation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty WidthAnimationProperty =
            DependencyProperty.Register(nameof(WidthAnimation), typeof(bool), typeof(Collapsable), new PropertyMetadata(false));

        /// <summary>
        /// Duration of the expanding and collapsing animations.
        /// </summary>
        public TimeSpan ExpandingAnimationTime
        {
            get => (TimeSpan)GetValue(ExpandingAnimationTimeProperty);
            set => SetValue(ExpandingAnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ExpandingAnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ExpandingAnimationTimeProperty =
            DependencyProperty.Register(nameof(ExpandingAnimationTime), typeof(TimeSpan), typeof(Collapsable), new PropertyMetadata(TimeSpan.Zero));

        /// <summary>
        /// Specifies if expanding or collapsing anination is currently executing.
        /// </summary>
        [Bindable(true)]
        public bool IsAnimating
        {
            get => isAnimating;
            private set
            {
                if (value != isAnimating)
                {
                    isAnimating = value;
                    RaiseAnimationEvent(value);
                }
            }
        }

        #region IsHeightAnimating / IsWidthAnimating

        private bool isHeightAnimating = false;
        private bool isWidthAnimating = false;

        /// <summary>
        /// Specifies if height anination is currently executing.
        /// </summary>
        private bool IsHeightAnimating
        {
            get => isHeightAnimating;
            set
            {
                isHeightAnimating = value;
                IsAnimating = IsHeightAnimating || IsWidthAnimating;
            }
        }

        /// <summary>
        /// Specifies if width anination is currently executing.
        /// </summary>
        private bool IsWidthAnimating
        {
            get => isWidthAnimating;
            set
            {
                isWidthAnimating = value;
                IsAnimating = IsHeightAnimating || IsWidthAnimating;
            }
        }

        #endregion

        /// <summary>
        /// Occurs when <see cref="IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ExpandedChangedEventArgs> IsExpandedChanged;

        /// <summary>
        /// Occurs when the collapsing or expanding animation is started.
        /// </summary>
        public event EventHandler AnimationStarted;

        /// <summary>
        /// Occurs when the collapsing or expanding animation ended.
        /// </summary>
        public event EventHandler AnimationEnded;


        /// <summary>
        /// Creates a new <see cref="Collapsable"/>.
        /// </summary>
        public Collapsable()
        {
            Loaded -= Collapsable_Loaded;
            Loaded += Collapsable_Loaded;
        }

        /// <summary>
        /// Called when <see cref="IsExpanded"/> is changed.
        /// </summary>
        /// <param name="newValue">Actual state of <see cref="IsExpanded"/>.</param>
        protected virtual void OnExpandedChanged(bool newValue)
        {
            if (loaded)
            {
                if (IsExpanded) Expand();
                else Collapse();
                IsExpandedChanged?.Invoke(this, new ExpandedChangedEventArgs(newValue));
            }
        }

        /// <summary>
        /// Called when <see cref="Collapsable"/> is loaded.
        /// </summary>
        private void Collapsable_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsExpanded) Collapse(false);
            loaded = true;
        }

        /// <summary>
        /// Starts the expanding process.
        /// </summary>
        /// <param name="animate">Specifies if to animate the process.</param>
        private void Expand(bool animate = true)
        {
            Size expandedSize = CalculateExpandedSize(false);

            if (HeightAnimation) AnimateHeight(animate ? ExpandingAnimationTime : TimeSpan.Zero, MinHeight, expandedSize.Height, preCollapsingSize.Height);
            if (WidthAnimation) AnimateWidth(animate ? ExpandingAnimationTime : TimeSpan.Zero, MinWidth, expandedSize.Width, preCollapsingSize.Width);
        }

        /// <summary>
        /// Starts the collapsing process.
        /// </summary>
        /// <param name="animate">Specifies if to animate the process.</param>
        private void Collapse(bool animate = true)
        {
            preCollapsingSize = new Size(Width, Height);
            Size expandedSize = CalculateExpandedSize(true);

            if (HeightAnimation) AnimateHeight(animate ? ExpandingAnimationTime : TimeSpan.Zero, expandedSize.Height, MinHeight, MinHeight);
            if (WidthAnimation) AnimateWidth(animate ? ExpandingAnimationTime : TimeSpan.Zero, expandedSize.Width, MinWidth, MinWidth);
        }

        /// <summary>
        /// Animates <see cref="FrameworkElement.Height"/> from a value to another.
        /// </summary>
        /// <param name="duration">Animation duration.</param>
        /// <param name="from">The value of the animation start.</param>
        /// <param name="to">The value of the animation end.</param>
        /// <param name="final">The final value that height must have.</param>
        private void AnimateHeight(TimeSpan duration, double from, double to, double final)
        {
            IsHeightAnimating = true;
            if (duration > TimeSpan.Zero)
            {
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = from,
                    To = to,
                    Duration = new Duration(duration)
                };
                animation.Completed += (o, e) =>
                {
                    SetCurrentValue(HeightProperty, final);
                    IsHeightAnimating = false;
                };
                BeginAnimation(HeightProperty, animation);
            }
            else
            {
                SetCurrentValue(HeightProperty, final);
                IsHeightAnimating = false;
            }
        }

        /// <summary>
        /// Animates <see cref="FrameworkElement.Width"/> from a value to another.
        /// </summary>
        /// <param name="duration">Animation duration.</param>
        /// <param name="from">The value of the animation start.</param>
        /// <param name="to">The value of the animation end.</param>
        /// <param name="final">The final value that width must have.</param>
        private void AnimateWidth(TimeSpan duration, double from, double to, double final)
        {
            IsWidthAnimating = true;
            if (duration > TimeSpan.Zero)
            {
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = from,
                    To = to,
                    Duration = new Duration(duration)
                };
                animation.Completed += (o, e) =>
                {
                    SetCurrentValue(WidthProperty, final);
                    IsWidthAnimating = false;
                };
                BeginAnimation(WidthProperty, animation);
            }
            else
            {
                SetCurrentValue(WidthProperty, final);
                IsWidthAnimating = false;
            }
        }

        /// <summary>
        /// Calculates the size of <see cref="Collapsable"/> on expanded state.
        /// </summary>
        /// <remarks>
        /// <para>If <see cref="Collapsable"/> is expanded will return <see cref="UIElement.RenderSize"/>.</para>
        /// <para>If <see cref="Collapsable"/> is collapsed will calculate the expanded size in this way:</para>
        /// <para>-> If <see cref="FrameworkElement.Width"/> or <see cref="FrameworkElement.Height"/> were <see cref="double.NaN"/> before collapsing,
        /// will rearrange the layout, then return <see cref="UIElement.RenderSize"/>.</para>
        /// <para>-> If <see cref="FrameworkElement.Width"/> and <see cref="FrameworkElement.Height"/> were both fixed before collapsing,
        /// will return <see cref="preCollapsingSize"/>
        /// (fixed to respect <see cref="FrameworkElement.MaxWidth"/> and <see cref="FrameworkElement.MaxHeight"/>).</para>
        /// </remarks>
        /// <returns>Size of <see cref="Collapsable"/> on expanded state.</returns>
        private Size CalculateExpandedSize(bool isExpanded)
        {
            if (isExpanded)
            {
                return RenderSize;
            }
            else
            {
                if (double.IsNaN(preCollapsingSize.Width) || double.IsNaN(preCollapsingSize.Height))
                {
                    SetCurrentValue(WidthProperty, preCollapsingSize.Width);
                    SetCurrentValue(HeightProperty, preCollapsingSize.Height);
                    InvalidateArrange();
                    UpdateLayout();
                    return RenderSize;
                }
                else
                {
                    return new Size(Math.Min(preCollapsingSize.Width, MaxWidth), Math.Min(preCollapsingSize.Height, MaxHeight));
                }
            }
        }

        /// <summary>
        /// Raise the animation event based on <see cref="IsAnimating"/> current value.
        /// </summary>
        /// <param name="isAnimating"><see cref="IsAnimating"/> current value.</param>
        private void RaiseAnimationEvent(bool isAnimating)
        {
            if (loaded)
            {
                if (isAnimating) AnimationStarted?.Invoke(this, new EventArgs());
                else AnimationEnded?.Invoke(this, new EventArgs());
            }
        }
    }
}
