﻿using FullControls.Core;
using System.Windows;
using System.Windows.Controls;

namespace FullControls.Controls
{
    /// <summary>
    /// Displays an empty menu item.
    /// </summary>
    public class FlatMenuSpace : Control
    {
        static FlatMenuSpace()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlatMenuSpace),
                new FrameworkPropertyMetadata(typeof(FlatMenuSpace)));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="FlatMenuSpace"/>.
        /// </summary>
        public FlatMenuSpace() : base()
        {
            Loaded += (o, e) => OnLoaded(e);
        }

        /// <summary>
        /// Called when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnLoaded(RoutedEventArgs e) { }

        /// <summary>
        /// Prepares the container for the item.
        /// </summary>
        /// <param name="container">Container to prepare.</param>
        /// <param name="item">Item contained.</param>
        internal static void PrepareContainer(FlatMenuItemContainer? container, FlatMenuSpace? item)
        {
            if (container != null && item != null)
            {
                container.IsEnabled = false;
                container.PrepareContainer(false, false);
            }
        }
    }
}
