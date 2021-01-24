namespace FullControls.Extra
{
    /// <summary>
    /// Provides static methods for some common mathematical functions.
    /// </summary>
    public static class MathV2
    {
        /// <summary>
        /// Fizes a 32-bit unsigned integer between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The 32-bit unsigned integer fixed between the minimum and the maximum value.</returns>
        public static uint Fix(uint val, uint min, uint max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes a 16-bit unsigned integer between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The 16-bit unsigned integer fixed between the minimum and the maximum value.</returns>
        public static ushort Fix(ushort val, ushort min, ushort max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes a single-precision floating-point number between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The single-precision floating-point fixed between the minimum and the maximum value.</returns>
        public static float Fix(float val, float min, float max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes an 8-bit signed integer between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The 8-bit signed integer fixed between the minimum and the maximum value.</returns>
        public static sbyte Fix(sbyte val, sbyte min, sbyte max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes a 64-bit signed integer between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The 64-bit signed integer fixed between the minimum and the maximum value.</returns>
        public static long Fix(long val, long min, long max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes a 64-bit unsigned integer between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The 64-bit unsigned integer fixed between the minimum and the maximum value.</returns>
        public static ulong Fix(ulong val, ulong min, ulong max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes a 16-bit signed integer between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The 16-bit signed integer fixed between the minimum and the maximum value.</returns>
        public static short Fix(short val, short min, short max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes a double-precision floating-point number between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The double-precision floating-point number fixed between the minimum and the maximum value.</returns>
        public static double Fix(double val, double min, double max) => val > min ? val < max ? val : max : min;

        /// <summary>
        /// Fizes a decimal number between a minimum and a maximum value.
        /// </summary>
        /// <param name="val">The value to fix.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The decimal number fixed between the minimum and the maximum value.</returns>
        public static decimal Fix(decimal val, decimal min, decimal max) => val > min ? val < max ? val : max : min;
    }
}
