using System.Windows;
using System.Windows.Shell;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// <para>Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.</para>
    /// <para>This window type supports round angles.</para>
    /// </summary>
    public class CornerWindow : WindowPlus
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(CornerWindow));


        static CornerWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CornerWindow),
                new FrameworkPropertyMetadata(typeof(CornerWindow)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CornerWindow"/>.
        /// </summary>
        public CornerWindow() : base() { }

        /// <inheritdoc/>
        protected override void OnInitializing()
        {
            base.OnInitializing();
            WindowStyle = WindowStyle.None;
            WindowChrome wc = new()
            {
                GlassFrameThickness = new Thickness(-1),
                NonClientFrameEdges = NonClientFrameEdges.None,
                UseAeroCaptionButtons = false,
                CaptionHeight = TITLEBAR_HEIGHT + OverflowMargin.Top,
                ResizeBorderThickness = ResizeThickness,
                CornerRadius = new CornerRadius()
            };
            WindowChrome.SetWindowChrome(this, wc);
        }

        /// <inheritdoc/>
        protected override Thickness CalcOverflowMargin() => new(20);

        /// <inheritdoc/>
        protected override void OnOverflowMarginChanged(Thickness thickness)
        {
            WindowChrome wc = WindowChrome.GetWindowChrome(this);
            if (wc != null) wc.CaptionHeight = TITLEBAR_HEIGHT + thickness.Top;
        }

        /// <inheritdoc/>
        protected override void OnResizeThicknessChanged(Thickness thickness)
        {
            base.OnResizeThicknessChanged(thickness);
            WindowChrome wc = WindowChrome.GetWindowChrome(this);
            if (wc != null) wc.ResizeBorderThickness = thickness;
        }
    }
}
