using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FullControls
{
    /// <summary>
    /// Defines a <see cref="Grid"/> that can be expanded or collapsed.
    /// </summary>
    public class CollapsableGrid : Grid
    {
        private bool loaded = false;
        private Size collapsedSize;
        private Size expandedSize;

        /// <summary>
        /// Specifies if the <see cref="Grid"/> is expanded (true) or collapsed (false).
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
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(CollapsableGrid),
                new PropertyMetadata(true, new PropertyChangedCallback((d, e) => ((CollapsableGrid)d).OnExpandedChanged((bool)e.NewValue)),
                    new CoerceValueCallback((d, o) => ((CollapsableGrid)d).IsAnimating ? d.GetValue(IsExpandedProperty) : o)));

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
            DependencyProperty.Register(nameof(ExpandingAnimationTime), typeof(TimeSpan), typeof(CollapsableGrid), new PropertyMetadata(TimeSpan.Zero));

        /// <summary>
        /// Specifies if expanding or collapsing anination is currently executing.
        /// </summary>
        public bool IsAnimating { get; private set; }

        /// <summary>
        /// Occurs when <see cref="IsExpanded"/> is changed.
        /// </summary>
        public event EventHandler<ExpandedChangedEventArgs> ExpandedChanged;


        /// <summary>
        /// Creates a new <see cref="CollapsableGrid"/>.
        /// </summary>
        public CollapsableGrid()
        {
            Loaded += CollapsableGrid_Loaded;
        }

        /// <inheritdoc/>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            if (!IsAnimating && (!loaded || IsExpanded)) expandedSize = sizeInfo.NewSize;
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
        /// Expands the <see cref="Grid"/>.
        /// </summary>
        private void Expand(bool animate = true)
        {
            IsAnimating = true;

            if (animate && ExpandingAnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation expand = new DoubleAnimation
                {
                    From = collapsedSize.Height,
                    To = expandedSize.Height,
                    Duration = new Duration(ExpandingAnimationTime)
                };
                expand.Completed += (s, e) => IsAnimating = false;
                BeginAnimation(HeightProperty, expand);
            }
            else
            {
                SetCurrentValue(HeightProperty, expandedSize.Height);
                IsAnimating = false;
            }
        }

        /// <summary>
        /// Collapses the <see cref="Grid"/>.
        /// </summary>
        private void Collapse(bool animate = true)
        {
            IsAnimating = true;

            if (animate && ExpandingAnimationTime > TimeSpan.Zero)
            {
                DoubleAnimation expand = new DoubleAnimation
                {
                    From = expandedSize.Height,
                    To = collapsedSize.Height,
                    Duration = new Duration(ExpandingAnimationTime)
                };
                expand.Completed += (s, e) => IsAnimating = false;
                BeginAnimation(HeightProperty, expand);
            }
            else
            {
                SetCurrentValue(HeightProperty, collapsedSize.Height);
                IsAnimating = false;
            }
        }

        /// <summary>
        /// Called when the control is loaded.
        /// </summary>
        private void CollapsableGrid_Loaded(object sender, RoutedEventArgs e)
        {
            loaded = true;
            if (IsExpanded) Expand(false);
            else Collapse(false);
        }
    }
}
