using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FullControls
{
    /// <summary>
    /// Defines a control that can be expanded or collapsed.
    /// </summary>
    public class Collapsable : Decorator
    {
        private bool loaded = false;
        private bool isAnimating = false;
        private Size preCollapsingSize;

        /// <summary>
        /// Specifies if the control is expanded (true) or collapsed (false).
        /// </summary>
        /// <remarks>If <see cref="IsAnimating"/> is true the value is reverted to the previous value.</remarks>
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
        /// Duration of the control animation when <see cref="IsExpanded"/> is changed.
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
        public bool IsAnimating
        {
            get => isAnimating;
            private set
            {
                isAnimating = value;
                RaiseAnimationEvent(value);
            }
        }

        /// <summary>
        /// Occurs when <see cref="IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ExpandedChangedEventArgs> ExpandedChanged;

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
                ExpandedChanged?.Invoke(this, new ExpandedChangedEventArgs(newValue));
            }
        }

        /// <summary>
        /// Called when the control is loaded.
        /// </summary>
        private void Collapsable_Loaded(object sender, RoutedEventArgs e)
        {
            if (!IsExpanded) Collapse(false);
            loaded = true;
        }

        /// <summary>
        /// Starts the control expanding process.
        /// </summary>
        private void Expand(bool animate = true)
        {
            IsAnimating = true;

            if (animate && ExpandingAnimationTime > TimeSpan.Zero)
            {
                Size expandedSize = CalculateExpandedSize(false);

                DoubleAnimation expand = new DoubleAnimation
                {
                    From = 0d,
                    To = expandedSize.Height,
                    Duration = new Duration(ExpandingAnimationTime)
                };
                expand.Completed += (s, e) =>
                {
                    SetCurrentValue(HeightProperty, preCollapsingSize.Height);
                    IsAnimating = false;
                    preCollapsingSize = Size.Empty;
                };
                BeginAnimation(HeightProperty, expand);
            }
            else
            {
                SetCurrentValue(HeightProperty, preCollapsingSize.Height);
                IsAnimating = false;
                preCollapsingSize = Size.Empty;
            }
        }

        /// <summary>
        /// Starts the control collapsing process.
        /// </summary>
        private void Collapse(bool animate = true)
        {
            IsAnimating = true;

            preCollapsingSize = new Size(Width, Height);

            if (animate && ExpandingAnimationTime > TimeSpan.Zero)
            {
                Size expandedSize = CalculateExpandedSize(true);

                DoubleAnimation collapse = new DoubleAnimation
                {
                    From = expandedSize.Height,
                    To = 0d,
                    Duration = new Duration(ExpandingAnimationTime)
                };
                collapse.Completed += (s, e) => IsAnimating = false;
                BeginAnimation(HeightProperty, collapse);
            }
            else
            {
                SetCurrentValue(HeightProperty, 0d);
                IsAnimating = false;
            }
        }

        /// <summary>
        /// Calculates the size of the control on expanded state.
        /// </summary>
        /// <remarks>
        /// <para>If the control is expanded will return <see cref="UIElement.RenderSize"/>.</para>
        /// <para>If the control is collapsed will calculate the expanded size in this way:</para>
        /// <para>-> If <see cref="FrameworkElement.Width"/> or <see cref="FrameworkElement.Height"/> were <see cref="double.NaN"/> before collapsing,
        /// will rearrange the layout, then return <see cref="UIElement.RenderSize"/>.</para>
        /// <para>-> If <see cref="FrameworkElement.Width"/> and <see cref="FrameworkElement.Height"/> were both fixed before collapsing,
        /// will return <see cref="preCollapsingSize"/>
        /// (fixed to respect <see cref="FrameworkElement.MaxWidth"/> and <see cref="FrameworkElement.MaxHeight"/>).</para>
        /// </remarks>
        /// <returns>Size of the control on expanded state.</returns>
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
