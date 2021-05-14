using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shell;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// <para>Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.</para>
    /// <para>This window type supports custom animations for state transitions, round angles, and custom shadow.</para>
    /// </summary>
    /// <remarks>
    /// <para>This window type is more performant than <see cref="FullWindow"/>
    /// because not uses <see cref="Window.AllowsTransparency"/> = <see langword="true"/>.</para>
    /// <para><see cref="Window.WindowStyle"/> can be only <see cref="WindowStyle.None"/>.</para>
    /// <para><see cref="Window.ResizeMode"/> can be only <see cref="ResizeMode.CanMinimize"/> or <see cref="ResizeMode.NoResize"/>.</para>
    /// </remarks>
    public class FlexWindow : CustomWindow
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
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(FlexWindow));

        /// <summary>
        /// Gets the opacity of the content.
        /// </summary>
        public double ContentOpacity => (double)GetValue(ContentOpacityProperty);

        #region ContentOpacityProperty

        /// <summary>
        /// The <see cref="DependencyPropertyKey"/> for <see cref="ContentOpacity"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey ContentOpacityPropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ContentOpacity), typeof(double), typeof(FlexWindow),
                new FrameworkPropertyMetadata(1d));

        /// <summary>
        /// Identifies the <see cref="ContentOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentOpacityProperty = ContentOpacityPropertyKey.DependencyProperty;

        /// <summary>
        /// Proxy for <see cref="ContentOpacity"/> dependency property.
        /// </summary>
        private static readonly DependencyProperty ContentOpacityPropertyProxy =
            DependencyProperty.Register("ContentOpacityProxy", typeof(double), typeof(FlexWindow),
                new FrameworkPropertyMetadata(1d, new PropertyChangedCallback((d, e)
                    => d.SetValue(ContentOpacityPropertyKey, e.NewValue))));

        #endregion


        static FlexWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlexWindow),
                new FrameworkPropertyMetadata(typeof(FlexWindow)));

            ResizeModeProperty.OverrideMetadata(typeof(FlexWindow),
                new FrameworkPropertyMetadata(ResizeMode.CanMinimize, null,
                new CoerceValueCallback((d, o) => o is ResizeMode.CanMinimize or ResizeMode.NoResize ?
                                                  o : ResizeMode.CanMinimize)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FlexWindow"/>.
        /// </summary>
        public FlexWindow() : base() { }

        /// <inheritdoc/>
        protected override void OnInitializing()
        {
            base.OnInitializing();
            WindowChrome wc = new()
            {
                GlassFrameThickness = new Thickness(-1),
                NonClientFrameEdges = NonClientFrameEdges.None,
                UseAeroCaptionButtons = false,
                CaptionHeight = EnableTitlebar ? TITLEBAR_HEIGHT + OutsideMargin.Top : 0,
                ResizeBorderThickness = ResizeThickness,
                CornerRadius = new CornerRadius()
            };
            WindowChrome.SetWindowChrome(this, wc);
        }

        /// <inheritdoc/>
        protected override Thickness CalcOutsideMargin()
        {
            double margin = ShadowRadius / 2;
            double offset = ShadowDepth;
            return new Thickness(Math.Max(0, Math.Ceiling(margin - offset)),
                                 Math.Max(0, Math.Ceiling(margin - offset)),
                                 Math.Max(0, Math.Ceiling(margin + offset)),
                                 Math.Max(0, Math.Ceiling(margin + offset)));
        }

        /// <inheritdoc/>
        protected override void OnOutsideMarginChanged(Thickness thickness)
        {
            WindowChrome wc = WindowChrome.GetWindowChrome(this);
            if (wc != null) wc.CaptionHeight = EnableTitlebar ? TITLEBAR_HEIGHT + thickness.Top : 0;
        }

        /// <inheritdoc/>
        protected override void OnResizeThicknessChanged(Thickness thickness)
        {
            base.OnResizeThicknessChanged(thickness);
            WindowChrome wc = WindowChrome.GetWindowChrome(this);
            if (wc != null) wc.ResizeBorderThickness = thickness;
        }

        /// <inheritdoc/>
        protected override Storyboard GetEnterAnimation()
        {
            Storyboard sb = new();
            sb.Children.Add(Util.GenerateDoubleAnimation(0, 1, AnimationTime, this, new PropertyPath(ContentOpacityPropertyProxy)));
            return sb;
        }

        /// <inheritdoc/>
        protected override Storyboard GetExitAnimation()
        {
            Storyboard sb = new();
            sb.Children.Add(Util.GenerateDoubleAnimation(1, 0, AnimationTime, this, new PropertyPath(ContentOpacityPropertyProxy)));
            return sb;
        }

        /// <inheritdoc/>
        protected override Storyboard GetMinimizeAnimation()
        {
            Storyboard sb = new();
            sb.Children.Add(Util.GenerateDoubleAnimation(1, 0, AnimationTime, this, new PropertyPath(ContentOpacityPropertyProxy)));
            return sb;
        }

        /// <inheritdoc/>
        protected override Storyboard GetRestoreFromMinimizedAnimation()
        {
            Storyboard sb = new();
            sb.Children.Add(Util.GenerateDoubleAnimation(0, 1, AnimationTime, this, new PropertyPath(ContentOpacityPropertyProxy)));
            return sb;
        }
    }
}
