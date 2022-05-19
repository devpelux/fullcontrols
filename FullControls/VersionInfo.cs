namespace FullControls
{
    /// <summary>
    /// Provides version informations about the <see cref="FullControls"/> package.
    /// </summary>
    public static class VersionInfo
    {
        /// <summary>
        /// Gets the current <see cref="FullControls"/> version code.
        /// </summary>
        public static string VersionCode => typeof(VersionInfo).Assembly.GetName().Version?.ToString() ?? string.Empty;
    }
}
