namespace FullControls.Common
{
    /// <summary>
    /// Represents an object with a <see cref="VState"/>.
    /// </summary>
    public interface IVState
    {
        /// <summary>
        /// Returns the current <see cref="VState"/>.
        /// </summary>
        public VState GetCurrentVState();
    }
}
