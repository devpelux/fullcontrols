using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FullControls
{
    /// <summary>
    /// A control that could be expanded or collapsed.
    /// </summary>
    public class Collapsable : Decorator
    {
        private bool loaded = false;
        private bool heightWasNaN = false;
        private bool calculatingSize = false;
        private Size availableSize;

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
        public bool IsAnimating { get; private set; }

        /// <summary>
        /// Occurs when <see cref="IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ExpandedChangedEventArgs> ExpandedChanged;


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

        /// <inheritdoc/>
        protected override Size MeasureOverride(Size constraint)
        {
            if (!calculatingSize && !IsAnimating)
            {
                availableSize = new Size(Math.Max(availableSize.Width, constraint.Width), Math.Max(availableSize.Height, constraint.Height));
            }
            return base.MeasureOverride(constraint);
        }

        /// <summary>
        /// Called when the control is loaded.
        /// </summary>
        private void Collapsable_Loaded(object sender, RoutedEventArgs e)
        {
            loaded = true;
            if (!IsExpanded) Collapse(false);
        }

        /// <summary>
        /// Starts the control expanding process.
        /// </summary>
        private void Expand(bool animate = true)
        {
            IsAnimating = true;

            Size expandedSize = CalculateExpandedSize();

            if (animate && ExpandingAnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation expand = new DoubleAnimation
                {
                    From = 0d,
                    To = expandedSize.Height,
                    Duration = new Duration(ExpandingAnimationTime)
                };
                expand.Completed += (s, e) =>
                {
                    IsAnimating = false;
                    if (heightWasNaN) SetCurrentValue(HeightProperty, double.NaN);
                    heightWasNaN = false;
                };
                BeginAnimation(HeightProperty, expand);
            }
            else
            {
                SetCurrentValue(HeightProperty, heightWasNaN ? double.NaN : expandedSize.Height);
                IsAnimating = false;
                heightWasNaN = false;
            }
        }

        /// <summary>
        /// Starts the control collapsing process.
        /// </summary>
        private void Collapse(bool animate = true)
        {
            IsAnimating = true;

            heightWasNaN = double.IsNaN(Height);

            Size expandedSize = CalculateExpandedSize();

            if (animate && ExpandingAnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation expand = new DoubleAnimation
                {
                    From = expandedSize.Height,
                    To = 0d,
                    Duration = new Duration(ExpandingAnimationTime)
                };
                expand.Completed += (s, e) => IsAnimating = false;
                BeginAnimation(HeightProperty, expand);
            }
            else
            {
                SetCurrentValue(HeightProperty, 0d);
                IsAnimating = false;
            }
        }

        /// <summary>
        /// Calculates size of the control on expanded state that must be smaller or equal to <see cref="availableSize"/>.
        /// </summary>
        /// <returns>Size of the control on expanded state.</returns>
        private Size CalculateExpandedSize()
        {
            calculatingSize = true;
            Size requestedSize = MeasureOverride(new Size(double.PositiveInfinity, double.PositiveInfinity));
            calculatingSize = false;
            return new Size(Math.Min(availableSize.Width, requestedSize.Width), Math.Min(availableSize.Height, requestedSize.Height));
        }
    }
}
