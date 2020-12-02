namespace FullControls
{
    /// <summary>
    /// Define an object that can return a result.
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// Get the result object.
        /// </summary>
        /// <returns>Result object.</returns>
        object GetResult();
    }
}
