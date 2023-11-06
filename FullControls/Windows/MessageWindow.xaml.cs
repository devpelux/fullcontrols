using FullControls.Common;
using FullControls.SystemControls;
using System;
using System.Media;
using System.Windows;
using System.Windows.Media;

namespace FullControls.Windows
{
    /// <summary>
    /// Simple message window with two buttons.
    /// Max message length is 400.
    /// </summary>
    public sealed partial class MessageWindow : AvalonWindow, IDialog<MessageWindow.Result>
    {
        /// <summary>
        /// Result of the window.
        /// </summary>
        private Result result = Result.Neutral;

        /// <summary>
        /// Initializes a new instance of <see cref="MessageWindow"/>.
        /// </summary>
        private MessageWindow(string message, string title, string? positive, string? negative, Type type, Theme theme, Window? owner)
        {
            InitializeComponent();

            //Sets the message and adapts the window.
            Message.Text = message[..Math.Min(400, message.Length)];
            if (message.Length > 45) Width = 300;

            //Sets the title.
            Title = title;

            //Sets the buttons (if content is null, the buttons are not displayed).
            Positive.Content = positive;
            if (positive == null) Positive.Visibility = Visibility.Collapsed;
            Negative.Content = negative;
            if (negative == null) Negative.Visibility = Visibility.Collapsed;

            //Sets the owner (if owner is null, the window is displayed at center screen).
            Owner = owner;
            if (Owner == null) WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Sets the image (if type is none, the image is not diaplayed).
            Image.Text = type switch
            {
                Type.Hand => "\xE711",
                Type.Question => "\xE897",
                Type.Exclamation => "\xE783",
                Type.Asterisk => "\xE946",
                _ => "",
            };
            if (type == Type.None) Image.Visibility = Visibility.Collapsed;

            //Sets the theme (If theme is dark the window is changed to dark mode).
            if (theme == Theme.Dark)
            {
                Style = (Style)FindResource("DarkAvalonWindow");
                BackgroundLayer.Background = (Brush)FindResource("DarkWindowTertiaryBackground");
                Positive.Style = (Style)FindResource("DarkButtonPlusActive");
                Negative.Style = (Style)FindResource("DarkButtonPlus");
            }

            //Sets the events for playing sound and closing the window by using buttons.
            Loaded += (s, e) => PlaySound(type);
            Positive.Click += (s, e) => SetResultAndClose(Result.Positive);
            Negative.Click += (s, e) => SetResultAndClose(Result.Negative);
        }

        /// <summary>
        /// Plays the system sound basing on the specified window type.
        /// </summary>
        private static void PlaySound(Type type)
        {
            switch (type)
            {
                case Type.Hand:
                    SystemSounds.Hand.Play();
                    break;
                case Type.Question:
                    SystemSounds.Question.Play();
                    break;
                case Type.Exclamation:
                    SystemSounds.Exclamation.Play();
                    break;
                case Type.Asterisk:
                    SystemSounds.Asterisk.Play();
                    break;
            }
        }

        /// <summary>
        /// Sets the result and closes the window.
        /// </summary>
        private void SetResultAndClose(Result result)
        {
            this.result = result;
            Close();
        }

        /// <inheritdoc/>
        public Result GetResult() => result;

        /// <summary>
        /// Creates a builder for <see cref="MessageWindow"/>.
        /// </summary>
        public static Builder GetBuilder() => new();


        #region Builder

        /// <summary>
        /// Builder of <see cref="MessageWindow"/>.
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Message of the <see cref="MessageWindow"/>.
            /// </summary>
            private string message = "";

            /// <summary>
            /// Title of the <see cref="MessageWindow"/>.
            /// </summary>
            private string title = "";

            /// <summary>
            /// Positive button content of the <see cref="MessageWindow"/>.
            /// </summary>
            private string? positive = null;

            /// <summary>
            /// Negative button content of the <see cref="MessageWindow"/>.
            /// </summary>
            private string? negative = null;

            /// <summary>
            /// Theme of the <see cref="MessageWindow"/>.
            /// </summary>
            private Theme theme = Theme.Light;

            /// <summary>
            /// Type of the <see cref="MessageWindow"/>.
            /// </summary>
            private Type type = Type.None;

            /// <summary>
            /// Owner of the <see cref="MessageWindow"/>.
            /// </summary>
            private Window? owner = null;

            /// <summary>
            /// Sets the message of the <see cref="MessageWindow"/>.
            /// </summary>
            public Builder WithMessage(string message)
            {
                this.message = message;
                return this;
            }

            /// <summary>
            /// Sets the message of the <see cref="MessageWindow"/>.
            /// </summary>
            public Builder WithTitle(string title)
            {
                this.title = title;
                return this;
            }

            /// <summary>
            /// Sets the positive button content of the <see cref="MessageWindow"/>.
            /// The button will be removed if the content is null.
            /// </summary>
            public Builder WithPositive(string? positive)
            {
                this.positive = positive;
                return this;
            }

            /// <summary>
            /// Sets the negative button content of the <see cref="MessageWindow"/>.
            /// The button will be removed if the content is null.
            /// </summary>
            public Builder WithNegative(string? negative)
            {
                this.negative = negative;
                return this;
            }

            /// <summary>
            /// Sets the theme of the <see cref="MessageWindow"/>.
            /// </summary>
            public Builder WithTheme(Theme theme)
            {
                this.theme = theme;
                return this;
            }

            /// <summary>
            /// Sets the type of the <see cref="MessageWindow"/>.
            /// </summary>
            public Builder WithType(Type type)
            {
                this.type = type;
                return this;
            }

            /// <summary>
            /// Sets the owner of the <see cref="MessageWindow"/>.
            /// The window will be rendered at center owner if the owner is non null, otherwise at center screen.
            /// </summary>
            public Builder WithOwner(Window? owner)
            {
                this.owner = owner;
                return this;
            }

            /// <summary>
            /// Builds and show the <see cref="MessageWindow"/> and, when it is closed, returns the result.
            /// </summary>
            public Result BuildAndShow() => new MessageWindow(message, title, positive, negative, type, theme, owner).ShowDialogForResult<Result>();
        }

        #endregion


        #region Type, theme, and result

        /// <summary>
        /// Type of <see cref="MessageWindow"/>.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Window with no sound and icon.
            /// </summary>
            None,

            /// <summary>
            /// Window with hand system sound and icon.
            /// </summary>
            Hand,

            /// <summary>
            /// Window with question system sound and icon.
            /// </summary>
            Question,

            /// <summary>
            /// Window with exclamation system sound and icon.
            /// </summary>
            Exclamation,

            /// <summary>
            /// Window with asterisk system sound and icon.
            /// </summary>
            Asterisk
        }

        /// <summary>
        /// Theme of <see cref="MessageWindow"/>.
        /// </summary>
        public enum Theme
        {
            /// <summary>
            /// Light theme.
            /// </summary>
            Light,

            /// <summary>
            /// Dark theme.
            /// </summary>
            Dark
        }

        /// <summary>
        /// Result type of <see cref="MessageWindow"/>.
        /// </summary>
        public enum Result
        {
            /// <summary>
            /// Neutral result.
            /// </summary>
            Neutral,

            /// <summary>
            /// Positive result.
            /// </summary>
            Positive,

            /// <summary>
            /// Negative result.
            /// </summary>
            Negative
        }

        #endregion
    }
}
