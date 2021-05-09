using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shell;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// <para>Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.</para>
    /// <para>This window type supports round angles and custom shadow.</para>
    /// </summary>
    public class FullWindow : CustomWindow
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FullWindow));

        /// <summary>
        /// Gets the opacity of the content.
        /// </summary>
        public double ContentOpacity => (double)GetValue(ContentOpacityProperty);

        #region ContentOpacityProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ContentOpacity"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ContentOpacityPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ContentOpacity), typeof(double), typeof(FullWindow),
                new FrameworkPropertyMetadata(1d));

        /// <summary>
        /// Identifies the <see cref="ContentOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentOpacityProperty = ContentOpacityPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ContentOpacity"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ContentOpacityPropertyProxy =
            DependencyProperty.Register("ContentOpacityProxy", typeof(double), typeof(FullWindow),
                new FrameworkPropertyMetadata(1d, new PropertyChangedCallback((d, e)
                    => d.SetValue(ContentOpacityPropertyKey, e.NewValue))));

        #endregion


        static FullWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FullWindow),
                new FrameworkPropertyMetadata(typeof(FullWindow)));

            AllowsTransparencyProperty.OverrideMetadata(typeof(FullWindow),
                new FrameworkPropertyMetadata(BoolBox.True, null,
                new CoerceValueCallback((d, o) => BoolBox.True)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FullWindow"/>.
        /// </summary>
        public FullWindow() : base() { }

        /// <inheritdoc/>
        protected override void OnInitializing()
        {
            base.OnInitializing();
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
        protected override Thickness CalcOverflowMargin()
        {
            if (!IsDocked)
            {
                if (WindowState != WindowState.Maximized)
                {
                    double margin = ShadowRadius / 2;
                    double offset = ShadowDepth;
                    return new Thickness(Math.Max(0, Math.Ceiling(margin - offset)),
                                         Math.Max(0, Math.Ceiling(margin - offset)),
                                         Math.Max(0, Math.Ceiling(margin + offset)),
                                         Math.Max(0, Math.Ceiling(margin + offset)));
                }
                else return WindowCore.WindowResizeBorderThickness;
            }
            else return new Thickness();
        }

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

        /// <inheritdoc/>
        protected override Timeline GetEnterAnimation()
            => Util.GenerateDoubleAnimation(0, 1, AnimationTime, this, new PropertyPath(ContentOpacityPropertyProxy));

        /// <inheritdoc/>
        protected override Timeline GetExitAnimation()
            => Util.GenerateDoubleAnimation(1, 0, AnimationTime, this, new PropertyPath(ContentOpacityPropertyProxy));

        /// <inheritdoc/>
        protected override Timeline GetMinimizeAnimation() => null;

        /// <inheritdoc/>
        protected override Timeline GetRestoreFromMinimizeAnimation() => null;
    }
}
