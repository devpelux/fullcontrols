using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace FullControls.Controls.Components
{
    /// <inheritdoc/>
    [DesignTimeVisible(false)]
    public sealed class GlassThumb : Thumb
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassThumb), new FrameworkPropertyMetadata(new CornerRadius()));


        static GlassThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassThumb), new FrameworkPropertyMetadata(typeof(GlassThumb)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GlassThumb"/>.
        /// </summary>
        public GlassThumb() : base() { }
    }
}
