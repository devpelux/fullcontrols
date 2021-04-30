using FullControls.Common;
using FullControls.Core;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FullControls.Controls
{
    /// <summary>
    /// Adds collapsing and expanding functionality to another element.
    /// </summary>
    public class Collapsible : Decorator
    {
        private bool loaded = false;
        private bool isAnimating = false;
        private Size preCollapsingSize;

        /// <summary>
        /// Gets or sets a value indicating if the <see cref="Collapsible"/> is expanded (<see langword="true"/>) or collapsed (<see langword="false"/>).
        /// </summary>
        /// <remarks>If <see cref="IsAnimating"/> is <see langword="true"/> the value is reverted to the previous value.</remarks>
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="IsExpanded"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(Collapsible),
                new PropertyMetadata(BoolBox.True, new PropertyChangedCallback((d, e) => ((Collapsible)d).OnExpandedChanged((bool)e.NewValue)),
                    new CoerceValueCallback((d, o) => ((Collapsible)d).IsAnimating ? d.GetValue(IsExpandedProperty) : o)));

        /// <summary>
        /// Gets or sets a value indicating if to enable the <see cref="FrameworkElement.Height"/> animation.
        /// </summary>
        public bool HeightAnimation
        {
            get => (bool)GetValue(HeightAnimationProperty);
            set => SetValue(HeightAnimationProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="HeightAnimation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HeightAnimationProperty =
            DependencyProperty.Register(nameof(HeightAnimation), typeof(bool), typeof(Collapsible), new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if to enable the <see cref="FrameworkElement.Width"/> animation.
        /// </summary>
        public bool WidthAnimation
        {
            get => (bool)GetValue(WidthAnimationProperty);
            set => SetValue(WidthAnimationProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="WidthAnimation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty WidthAnimationProperty =
            DependencyProperty.Register(nameof(WidthAnimation), typeof(bool), typeof(Collapsible), new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Gets or sets the duration of the expanding and collapsing animations.
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
            DependencyProperty.Register(nameof(ExpandingAnimationTime), typeof(TimeSpan), typeof(Collapsible), new PropertyMetadata(TimeSpan.Zero));

        /// <summary>
        /// Gets a value indicating if expanding or collapsing anination is currently executing.
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
        /// Gets a value indicating if height anination is currently executing.
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
        /// Gets a value indicating if width anination is currently executing.
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
        /// Occurs when the collapsing or expanding animation started.
        /// </summary>
        public event EventHandler AnimationStarted;

        /// <summary>
        /// Occurs when the collapsing or expanding animation ended.
        /// </summary>
        public event EventHandler AnimationEnded;


        /// <summary>
        /// Initializes a new instance of <see cref="Collapsible"/>.
        /// </summary>
        public Collapsible() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e)
        {
            if (!IsExpanded) Collapse(false);
            loaded = true;
        }

        /// <summary>
        /// Called when <see cref="IsExpanded"/> is changed.
        /// </summary>
        /// <param name="isExpanded">Actual state of <see cref="IsExpanded"/>.</param>
        protected virtual void OnExpandedChanged(bool isExpanded)
        {
            if (loaded)
            {
                //Starts the animation
                if (IsExpanded) Expand();
                else Collapse();
                //Raises the ExpandedChanged event
                IsExpandedChanged?.Invoke(this, new ExpandedChangedEventArgs(isExpanded));
            }
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
                DoubleAnimation animation = new()
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
                DoubleAnimation animation = new()
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
        /// Calculates the size of <see cref="Collapsible"/> on expanded state.
        /// </summary>
        /// <remarks>
        /// <para>If <see cref="Collapsible"/> is expanded will return <see cref="UIElement.RenderSize"/>.</para>
        /// <para>If <see cref="Collapsible"/> is collapsed will calculate the expanded size in this way:</para>
        /// <para>-> If <see cref="FrameworkElement.Width"/> or <see cref="FrameworkElement.Height"/> were <see cref="double.NaN"/> before collapsing,
        /// will rearrange the layout, then return <see cref="UIElement.RenderSize"/>.</para>
        /// <para>-> If <see cref="FrameworkElement.Width"/> and <see cref="FrameworkElement.Height"/> were both fixed before collapsing,
        /// will return <see cref="preCollapsingSize"/>
        /// (fixed to respect <see cref="FrameworkElement.MaxWidth"/> and <see cref="FrameworkElement.MaxHeight"/>).</para>
        /// </remarks>
        /// <returns>Size of <see cref="Collapsible"/> on expanded state.</returns>
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
