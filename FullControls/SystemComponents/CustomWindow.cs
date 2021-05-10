using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using FullControls.Extra.Extensions;

namespace FullControls.SystemComponents
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
        protected abstract Timeline GetEnterAnimation();

        /// <summary>
        /// Gets the exit animation of the window. (<see langword="null"/> equals to not animate)
        /// </summary>
        /// <returns>Exit animation timeline.</returns>
        protected abstract Timeline GetExitAnimation();

        /// <summary>
        /// Gets the minimize animation of the window. (<see langword="null"/> equals to not animate)
        /// </summary>
        /// <returns>Minimize animation timeline.</returns>
        protected abstract Timeline GetMinimizeAnimation();

        /// <summary>
        /// Gets the restore animation of the window. (<see langword="null"/> equals to not animate)
        /// </summary>
        /// <returns>Restore animation timeline.</returns>
        protected abstract Timeline GetRestoreFromMinimizeAnimation();

        /// <inheritdoc/>
        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);
            if (WindowState != WindowState.Minimized)
            {
                if (GetEnterAnimation() is Timeline anim) Animate(anim);
            }
        }

        /// <inheritdoc/>
        protected override void OnStateChanged(WindowState state, WindowState prevState)
        {
            base.OnStateChanged(state, prevState);
            if (prevState == WindowState.Minimized)
            {
                if (GetRestoreFromMinimizeAnimation() is Timeline anim) Animate(anim);
            }
        }

        /// <inheritdoc/>
        public override async void Close()
        {
            if (RequestClose())
            {
                if (GetExitAnimation() is Timeline anim) await AnimateAsync(anim);
                PerformClose();
            }
        }

        /// <inheritdoc/>
        public override async void Minimize()
        {
            if (RequestMinimize())
            {
                if (GetMinimizeAnimation() is Timeline anim) await AnimateAsync(anim);
                PerformMinimize();
            }
        }

        #region Animation

        //Storyboard generators and starters.

        private static async Task AnimateAsync(Timeline animation)
        {
            Storyboard sb = new();
            sb.Children.Add(animation);
            await sb.BeginAsync();
        }

        private static void Animate(Timeline animation)
        {
            Storyboard sb = new();
            sb.Children.Add(animation);
            sb.Begin();
        }

        #endregion
    }
}
