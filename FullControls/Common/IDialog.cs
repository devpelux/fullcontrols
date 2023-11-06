namespace FullControls.Common
{
    /// <summary>
    /// Defines an object that can return a result.
    /// </summary>
    public interface IDialog<T>
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        public T? GetResult();
    }
}
