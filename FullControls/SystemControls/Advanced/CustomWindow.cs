using FullControls.Core;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FullControls.SystemControls.Advanced
{
    /// <summary>
    /// <para>Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.</para>
    /// <para>This window type supports custom animations for state transitions and custom shadow.</para>
    /// </summary>
    /// <remarks><see cref="Window.WindowStyle"/> can be only <see cref="WindowStyle.None"/>.</remarks>
    public abstract class CustomWindow : WindowPlus
    {
        #region Shadow

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowColor"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register(nameof(ShadowColor), typeof(Color), typeof(CustomWindow));

        /// <summary>
        /// Gets or sets the opacity of the shadow.
        /// </summary>
        public double ShadowOpacity
        {
            get => (double)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowOpacity"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register(nameof(ShadowOpacity), typeof(double), typeof(CustomWindow));

        /// <summary>
        /// Gets or sets the radius of the shadow.
        /// </summary>
        public double ShadowRadius
        {
            get => (double)GetValue(ShadowRadiusProperty);
            set => SetValue(ShadowRadiusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowRadius"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowRadiusProperty =
            DependencyProperty.Register(nameof(ShadowRadius), typeof(double), typeof(CustomWindow),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure,
                    new PropertyChangedCallback((d, e) => ((CustomWindow)d).UpdateOutsideMargin())));

        /// <summary>
        /// Gets or sets the depth of the shadow.
        /// </summary>
        public double ShadowDepth
        {
            get => (double)GetValue(ShadowDepthProperty);
            set => SetValue(ShadowDepthProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ShadowDepth"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShadowDepthProperty =
            DependencyProperty.Register(nameof(ShadowDepth), typeof(double), typeof(CustomWindow),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure,
                    new PropertyChangedCallback((d, e) => ((CustomWindow)d).UpdateOutsideMargin())));

        #endregion

        /// <summary>
        /// Gets or sets a value indicating if enable the enter and exit animations.
        /// </summary>
        public bool EnableEnterExitAnimations
        {
            get => (bool)GetValue(EnableEnterExitAnimationsProperty);
            set => SetValue(EnableEnterExitAnimationsProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableEnterExitAnimations"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableEnterExitAnimationsProperty =
            DependencyProperty.Register(nameof(EnableEnterExitAnimations), typeof(bool), typeof(CustomWindow),
                new PropertyMetadata(BoolBox.True));

        /// <summary>
        /// Gets or sets a value indicating if enable the minimize and restore animations.
        /// </summary>
        public bool EnableMinimizeRestoreAnimations
        {
            get => (bool)GetValue(EnableMinimizeRestoreAnimationsProperty);
            set => SetValue(EnableMinimizeRestoreAnimationsProperty, BoolBox.Box(value));
        }

        /// <summary>
        /// Identifies the <see cref="EnableMinimizeRestoreAnimations"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty EnableMinimizeRestoreAnimationsProperty =
            DependencyProperty.Register(nameof(EnableMinimizeRestoreAnimations), typeof(bool), typeof(CustomWindow),
                new PropertyMetadata(BoolBox.False));

        /// <summary>
        /// Gets or sets the duration of the state change animations.
        /// </summary>
        public TimeSpan AnimationTime
        {
            get => (TimeSpan)GetValue(AnimationTimeProperty);
            set => SetValue(AnimationTimeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="AnimationTime"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AnimationTimeProperty =
            DependencyProperty.Register(nameof(AnimationTime), typeof(TimeSpan), typeof(CustomWindow));


        static CustomWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomWindow),
                new FrameworkPropertyMetadata(typeof(CustomWindow)));

            WindowStyleProperty.OverrideMetadata(typeof(CustomWindow),
                new FrameworkPropertyMetadata(WindowStyle.None, null,
                new CoerceValueCallback((d, o) => WindowStyle.None)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CustomWindow"/>.
        /// </summary>
        public CustomWindow() : base() { }

        /// <summary>
        /// Gets the enter animation of the window. (<see langword="null"/> equals to not animate)
        /// </summary>
        /// <returns>Enter animation timeline.</returns>
        protected abstract Storyboard GetEnterAnimation();

        /// <summary>
        /// Gets the exit animation of the window. (<see langword="null"/> equals to not animate)
        /// </summary>
        /// <returns>Exit animation timeline.</returns>
        protected abstract Storyboard GetExitAnimation();

        /// <summary>
        /// Gets the minimize animation of the window. (<see langword="null"/> equals to not animate)
        /// </summary>
        /// <returns>Minimize animation timeline.</returns>
        protected abstract Storyboard GetMinimizeAnimation();

        /// <summary>
        /// Gets the restore from minimized animation of the window. (<see langword="null"/> equals to not animate)
        /// </summary>
        /// <returns>Restore animation timeline.</returns>
        protected abstract Storyboard GetRestoreFromMinimizedAnimation();

        /// <inheritdoc/>
        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);
            if (WindowState != WindowState.Minimized)
            {
                if (EnableEnterExitAnimations && GetEnterAnimation() is Storyboard anim) anim.Begin();
            }
        }

        /// <inheritdoc/>
        protected override void OnStateChanged(WindowState state, WindowState prevState)
        {
            base.OnStateChanged(state, prevState);
            if (prevState == WindowState.Minimized)
            {
                if (EnableMinimizeRestoreAnimations && GetRestoreFromMinimizedAnimation() is Storyboard anim) anim.Begin();
            }
        }

        /// <inheritdoc/>
        public override async void Close()
        {
            if (RequestClose())
            {
                if (EnableEnterExitAnimations && GetExitAnimation() is Storyboard anim) await Util.AnimateStoryboardAsync(anim);
                PerformClose();
            }
        }

        /// <inheritdoc/>
        public override async void Minimize()
        {
            if (RequestMinimize())
            {
                if (EnableMinimizeRestoreAnimations && GetMinimizeAnimation() is Storyboard anim) await Util.AnimateStoryboardAsync(anim);
                PerformMinimize();
            }
        }
    }
}
