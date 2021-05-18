// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// LICENSE: https://github.com/dotnet/wpf/blob/main/LICENSE.TXT

using FullControls.Extra.Extensions;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Shell;

namespace FullControls.Core.Services
{
    internal static class SysParams
    {
        private static readonly BitArray _cacheValid = new((int)CacheSlot.NumSlots);

        #region DpiX

        private static int _dpiX;

        internal static int DpiX
        {
            get
            {
                if (!_cacheValid[(int)CacheSlot.DpiX])
                {
                    lock (_cacheValid)
                    {
                        if (!_cacheValid[(int)CacheSlot.DpiX])
                        {
                            HandleRef desktopWnd = new(null, IntPtr.Zero);

                            // Win32Exception will get the Win32 error code so we don't have to
                            IntPtr dc = InternalMethods.GetDC(desktopWnd);

                            // Detecting error case from unmanaged call, required by PREsharp to throw a Win32Exception
                            if (dc == IntPtr.Zero)
                            {
                                throw new Win32Exception();
                            }

                            try
                            {
                                _dpiX = NativeMethods.GetDeviceCaps(new HandleRef(null, dc), (int)DeviceCap.LOGPIXELSX);
                                _cacheValid[(int)CacheSlot.DpiX] = true;
                            }
                            finally
                            {
                                InternalMethods.ReleaseDC(desktopWnd, new HandleRef(null, dc));
                            }
                        }
                    }
                }

                return _dpiX;
            }
        }

        #endregion

        #region DpiY

        private static int _dpiY;

        internal static int DpiY
        {
            get
            {
                if (!_cacheValid[(int)CacheSlot.DpiY])
                {
                    lock (_cacheValid)
                    {
                        if (!_cacheValid[(int)CacheSlot.DpiY])
                        {
                            HandleRef desktopWnd = new(null, IntPtr.Zero);

                            // Win32Exception will get the Win32 error code so we don't have to
                            IntPtr dc = InternalMethods.GetDC(desktopWnd);

                            // Detecting error case from unmanaged call, required by PREsharp to throw a Win32Exception
                            if (dc == IntPtr.Zero)
                            {
                                throw new Win32Exception();
                            }

                            try
                            {
                                _dpiY = NativeMethods.GetDeviceCaps(new HandleRef(null, dc), (int)DeviceCap.LOGPIXELSY);
                                _cacheValid[(int)CacheSlot.DpiY] = true;
                            }
                            finally
                            {
                                InternalMethods.ReleaseDC(desktopWnd, new HandleRef(null, dc));
                            }
                        }
                    }
                }

                return _dpiY;
            }
        }

        internal static int Dpi => DpiY;

        #endregion

        #region WindowResizeBorderThickness

        private static Thickness _windowResizeBorderThickness;

        /// <summary>
        /// Standard thickness of the resize border of a window.
        /// </summary>
        public static Thickness WindowResizeBorderThickness
        {
            get
            {
                if (!_cacheValid[(int)CacheSlot.WindowResizeBorderThickness])
                {
                    lock (_cacheValid)
                    {
                        if (!_cacheValid[(int)CacheSlot.WindowResizeBorderThickness])
                        {
                            float dpix = ConvertInPixelsPerDip(DpiX);
                            float dpiy = ConvertInPixelsPerDip(DpiY);

                            Size frameSize = new(NativeMethods.GetSystemMetrics(SM.CXSIZEFRAME), NativeMethods.GetSystemMetrics(SM.CYSIZEFRAME));

                            // this adjustment is needed only since .NET 4.5 
                            Size paddedBorder = SizeExtensions.UniformSize(NativeMethods.GetSystemMetrics(SM.CXPADDEDBORDER));
                            frameSize = frameSize.Add(paddedBorder);

                            Size frameSizeInDips = DpiHelper.DeviceSizeToLogical(frameSize, dpix, dpiy);

                            _windowResizeBorderThickness = new Thickness(frameSizeInDips.Width, frameSizeInDips.Height, frameSizeInDips.Width, frameSizeInDips.Height);
                            _cacheValid[(int)CacheSlot.WindowResizeBorderThickness] = true;
                        }
                    }
                }

                return _windowResizeBorderThickness;
            }
        }

        /// <summary>
        /// Offset margin based on <see cref="SystemParameters.WindowResizeBorderThickness"/>
        /// when <see cref="WindowChrome.NonClientFrameEdges"/> is set to <see cref="NonClientFrameEdges.Bottom"/>.
        /// </summary>
        public static Thickness WindowFrameThickness => new(0d, 0d, 0d, SystemParameters.WindowResizeBorderThickness.Bottom);

        #endregion


        /// <summary>
        /// Gets the number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this 
        /// value is 1.0f. If the DPI is 120, this value is 120.0f/96.
        /// </summary>
        internal static float ConvertInPixelsPerDip(int dpi) => ((float)dpi) / 96;
    }
}
