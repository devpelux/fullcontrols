using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace FullControls.Controls
{
    /// <inheritdoc/>
    [DesignTimeVisible(false)]
    public sealed class GlassRepeatButton : RepeatButton
    {
        /// <summary>
        /// Gets or sets the corner radius of the control.
        /// </summary>
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="CornerRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassRepeatButton),
                new FrameworkPropertyMetadata(default(CornerRadius)));

        /// <summary>
        /// Gets or sets the opacity of the content.
        /// </summary>
        public double ContentOpacity
        {
            get => (double)GetValue(ContentOpacityProperty);
            set => SetValue(ContentOpacityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ContentOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentOpacityProperty =
            DependencyProperty.Register(nameof(ContentOpacity), typeof(double), typeof(GlassRepeatButton),
                new FrameworkPropertyMetadata(1d));


        static GlassRepeatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassRepeatButton), new FrameworkPropertyMetadata(typeof(GlassRepeatButton)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GlassRepeatButton"/>.
        /// </summary>
        public GlassRepeatButton() : base() { }
    }
}
