// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// LICENSE: https://github.com/dotnet/wpf/blob/main/LICENSE.TXT

namespace FullControls.Core.Service
{
    internal static class CommonHandles
    {
        static CommonHandles() { }

        /// <devdoc>
        ///     Handle type for accelerator tables.
        /// </devdoc>
        internal static readonly int Accelerator = HandleCollector.RegisterType("Accelerator", 80, 50);

        /// <devdoc>
        ///     handle type for cursors.
        /// </devdoc>
        internal static readonly int Cursor = HandleCollector.RegisterType("Cursor", 20, 500);

        /// <devdoc>
        ///     Handle type for enhanced metafiles.
        /// </devdoc>
        internal static readonly int EMF = HandleCollector.RegisterType("EnhancedMetaFile", 20, 500);

        /// <devdoc>
        ///     Handle type for file find handles.
        /// </devdoc>
        internal static readonly int Find = HandleCollector.RegisterType("Find", 0, 1000);

        /// <devdoc>
        ///     Handle type for GDI objects.
        /// </devdoc>
        internal static readonly int GDI = HandleCollector.RegisterType("GDI", 50, 500);

        /// <devdoc>
        ///     Handle type for HDC's that count against the Win98 limit of five DC's.  HDC's
        ///     which are not scarce, such as HDC's for bitmaps, are counted as GDIHANDLE's.
        /// </devdoc>
        internal static readonly int HDC = HandleCollector.RegisterType("HDC", 100, 2); // wait for 2 dc's before collecting

        /// <devdoc>
        ///     Handle type for icons.
        /// </devdoc>
        internal static readonly int Icon = HandleCollector.RegisterType("Icon", 20, 500);

        /// <devdoc>
        ///     Handle type for kernel objects.
        /// </devdoc>
        internal static readonly int Kernel = HandleCollector.RegisterType("Kernel", 0, 1000);

        /// <devdoc>
        ///     Handle type for files.
        /// </devdoc>
        internal static readonly int Menu = HandleCollector.RegisterType("Menu", 30, 1000);

        /// <devdoc>
        ///     Handle type for windows.
        /// </devdoc>
        internal static readonly int Window = HandleCollector.RegisterType("Window", 5, 1000);
    }
}
