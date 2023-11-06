// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// LICENSE: https://github.com/dotnet/wpf/blob/main/LICENSE.TXT
// REF: https://github.com/dotnet/wpf/blob/v6.0.0-rtm.21523.1/src/Microsoft.DotNet.Wpf/src/Shared/MS/Internal/DoubleUtil.cs

using System;
using System.Windows;

namespace FullControls.Core
{
    /// <summary>
    /// Provides "fuzzy" comparison functionality for doubles and some common double-based classes and structs.
    /// </summary>
    internal static class MathUtil
    {
        /// <summary>
        /// The smallest <see cref="double"/> such that <b>1.0 + DOUBLE_EPSILON != 1.0</b>.
        /// </summary>
        /// <remarks>
        /// This value comes from <see langword="sdk\inc\crt\float.h"/>.
        /// </remarks>
        internal const double DOUBLE_EPSILON = 2.2204460492503131e-016;


        /// <summary>
        /// Returns whether or not two <see cref="double"/> are close.
        /// </summary>
        /// <param name="value1">The first <see cref="double"/> to compare.</param>
        /// <param name="value2">The second <see cref="double"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="double"/> are close, otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// That is, whether or not they are within epsilon of each other.
        /// Note that this epsilon is proportional to the numbers themselves to that <see cref="AreClose(double, double)"/>
        /// survives scalar multiplication.
        /// There are plenty of ways for this to return <see langword="false"/> even for numbers which
        /// are theoretically identical, so no code calling this should fail to work if this returns <see langword="false"/>.
        /// <b>This should be used for optimizations only</b>.
        /// </remarks>
        internal static bool AreClose(double value1, double value2)
        {
            if (value1 == value2) return true;
            double eps = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * DOUBLE_EPSILON;
            double delta = value1 - value2;
            return (-eps < delta) && (eps > delta);
        }

        /// <summary>
        /// Returns whether or not the first <see cref="double"/> is less than the second <see cref="double"/>.
        /// </summary>
        /// <param name="value1">The first <see cref="double"/> to compare.</param>
        /// <param name="value2">The second <see cref="double"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the first <see cref="double"/> is less than the second <see cref="double"/>,
        /// otherwise <see langword="false"/>.
        /// bool - the result of the LessThan comparision.
        /// </returns>
        /// <remarks>
        /// That is, whether or not the first is strictly less than and not within epsilon of the other number.
        /// Note that this epsilon is proportional to the numbers themselves to that <see cref="AreClose(double, double)"/>
        /// survives scalar multiplication.
        /// There are plenty of ways for this to return <see langword="false"/> even for numbers which
        /// are theoretically identical, so no code calling this should fail to work if this returns <see langword="false"/>.
        /// <b>This should be used for optimizations only</b>.
        /// </remarks>
        internal static bool LessThan(double value1, double value2) => (value1 < value2) && !AreClose(value1, value2);

        /// <summary>
        /// Returns whether or not the first <see cref="double"/> is greater than the second <see cref="double"/>.
        /// </summary>
        /// <param name="value1">The first <see cref="double"/> to compare.</param>
        /// <param name="value2">The second <see cref="double"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the first <see cref="double"/> is greater than the second <see cref="double"/>,
        /// otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// That is, whether or not the first is strictly greater than and not within epsilon of the other number.
        /// Note that this epsilon is proportional to the numbers themselves to that <see cref="AreClose(double, double)"/>
        /// survives scalar multiplication.
        /// There are plenty of ways for this to return <see langword="false"/> even for numbers which
        /// are theoretically identical, so no code calling this should fail to work if this returns <see langword="false"/>.
        /// <b>This should be used for optimizations only</b>.
        /// </remarks>
        internal static bool GreaterThan(double value1, double value2) => (value1 > value2) && !AreClose(value1, value2);

        /// <summary>
        /// Returns whether or not the first <see cref="double"/> is less than or close to the second <see cref="double"/>.
        /// </summary>
        /// <param name="value1">The first <see cref="double"/> to compare.</param>
        /// <param name="value2">The second <see cref="double"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the first <see cref="double"/> is less than or close to the second <see cref="double"/>,
        /// otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// That is, whether or not the first is strictly less than or within epsilon of the other number.
        /// Note that this epsilon is proportional to the numbers themselves to that <see cref="AreClose(double, double)"/>
        /// survives scalar multiplication.
        /// There are plenty of ways for this to return <see langword="false"/> even for numbers which
        /// are theoretically identical, so no code calling this should fail to work if this returns <see langword="false"/>.
        /// <b>This should be used for optimizations only</b>.
        /// </remarks>
        internal static bool LessThanOrClose(double value1, double value2) => (value1 < value2) || AreClose(value1, value2);

        /// <summary>
        /// Returns whether or not the first <see cref="double"/> is greater than or close to the second <see cref="double"/>.
        /// </summary>
        /// <param name="value1">The first <see cref="double"/> to compare.</param>
        /// <param name="value2">The second <see cref="double"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the first <see cref="double"/> is greater than or close to the second <see cref="double"/>,
        /// otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// That is, whether or not the first is strictly greater than or within epsilon of the other number.
        /// Note that this epsilon is proportional to the numbers themselves to that <see cref="AreClose(double, double)"/>
        /// survives scalar multiplication.
        /// There are plenty of ways for this to return <see langword="false"/> even for numbers which
        /// are theoretically identical, so no code calling this should fail to work if this returns <see langword="false"/>.
        /// <b>This should be used for optimizations only</b>.
        /// </remarks>
        internal static bool GreaterThanOrClose(double value1, double value2) => (value1 > value2) || AreClose(value1, value2);

        /// <summary>
        /// Returns whether or not the <see cref="double"/> is close to 1.
        /// </summary>
        /// <param name="value">The <see cref="double"/> to compare to 1.</param>
        /// <returns>
        /// <see langword="true"/> the <see cref="double"/> is close to 1, otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsOne(double value) => Math.Abs(value - 1.0) < 10.0 * DOUBLE_EPSILON;

        /// <summary>
        /// Returns whether or not the <see cref="double"/> is close to 0.
        /// </summary>
        /// <param name="value">The <see cref="double"/> to compare to 0.</param>
        /// <returns>
        /// <see langword="true"/> the <see cref="double"/> is close to 0, otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsZero(double value) => Math.Abs(value) < 10.0 * DOUBLE_EPSILON;

        /// <summary>
        /// Returns whether or not the <see cref="double"/> is between 0 and 1.
        /// </summary>
        /// <param name="value">The <see cref="double"/> to check.</param>
        /// <returns>
        /// <see langword="true"/> the <see cref="double"/> is between 0 and 1, otherwise <see langword="false"/>.
        /// </returns>
        internal static bool IsBetweenZeroAndOne(double value) => GreaterThanOrClose(value, 0) && LessThanOrClose(value, 1);

        /// <summary>
        /// Compares two <see cref="Point"/> for fuzzy equality.
        /// </summary>
        /// <param name='point1'>The first <see cref="Point"/> to compare.</param>
        /// <param name='point2'>The second <see cref="Point"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="Point"/> are equal, otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// This function helps compensate for the fact that <see cref="double"/> values can 
        /// acquire error when operated upon.
        /// </remarks>
        internal static bool AreClose(Point point1, Point point2) => AreClose(point1.X, point2.X) && AreClose(point1.Y, point2.Y);

        /// <summary>
        /// Compares two <see cref="Size"/> for fuzzy equality.
        /// </summary>
        /// <param name='size1'>The first <see cref="Size"/> to compare.</param>
        /// <param name='size2'>The second <see cref="Size"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="Size"/> are equal, otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// This function helps compensate for the fact that <see cref="double"/> values can 
        /// acquire error when operated upon.
        /// </remarks>
        internal static bool AreClose(Size size1, Size size2) => AreClose(size1.Width, size2.Width) && AreClose(size1.Height, size2.Height);

        /// <summary>
        /// Compares two <see cref="Vector"/> for fuzzy equality.
        /// </summary>
        /// <param name='vector1'>The first <see cref="Vector"/> to compare.</param>
        /// <param name='vector2'>The second <see cref="Vector"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="Vector"/> are equal, otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// This function helps compensate for the fact that <see cref="double"/> values can 
        /// acquire error when operated upon.
        /// </remarks>
        internal static bool AreClose(Vector vector1, Vector vector2) => AreClose(vector1.X, vector2.X) && AreClose(vector1.Y, vector2.Y);

        /// <summary>
        /// Compares two <see cref="Rect"/> for fuzzy equality.
        /// </summary>
        /// <param name='rect1'>The first <see cref="Rect"/> to compare.</param>
        /// <param name='rect2'>The second <see cref="Rect"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if the two <see cref="Rect"/> are equal, otherwise <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// This function helps compensate for the fact that <see cref="double"/> values can 
        /// acquire error when operated upon.
        /// </remarks>
        internal static bool AreClose(Rect rect1, Rect rect2)
            => rect1.IsEmpty ? rect2.IsEmpty
                             : (!rect2.IsEmpty) && AreClose(rect1.X, rect2.X) && AreClose(rect1.Y, rect2.Y)
                                && AreClose(rect1.Height, rect2.Height) && AreClose(rect1.Width, rect2.Width);
    }
}
