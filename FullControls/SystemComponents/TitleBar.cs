using System.Windows;
using System.Windows.Controls;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Represents a generic title bar.
    /// </summary>
    public abstract class TitleBar : Control
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(TitleBar));


        static TitleBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitleBar),
                new FrameworkPropertyMetadata(typeof(TitleBar)));

            IsEnabledProperty.OverrideMetadata(typeof(TitleBar),
                new FrameworkPropertyMetadata(new PropertyChangedCallback((d, e)
                => ((TitleBar)d).OnEnabledChanged((bool)e.NewValue))));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TitleBar"/>.
        /// </summary>
        public TitleBar() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

        /// <summary>
        /// Called when the <see cref="UIElement.IsEnabled"/> is changed.
        /// </summary>
        /// <param name="enabledState">Actual state of <see cref="UIElement.IsEnabled"/>.</param>
        protected virtual void OnEnabledChanged(bool enabledState) { }
    }
}
