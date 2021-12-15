namespace FullControls.Common
{
    /// <summary>
    /// Defines an object that can return a result.
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// Get the result <see cref="object"/>.
        /// </summary>
        /// <returns>Result <see cref="object"/>.</returns>
        public object? GetResult();
    }
}
