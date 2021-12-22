namespace FullControls.Common
{
    /// <summary>
    /// Represents an object that can change <see cref="VState"/>.
    /// </summary>
    public interface IVState
    {
        /// <summary>
        /// Returns the current <see cref="VState"/>.
        /// </summary>
        public VState GetCurrentVState();
    }
}
