using System;

namespace FullControls.SystemComponents
{
    /// <summary>
    /// Defines an object that can return a result.
    /// </summary>
    [Obsolete("IDialog has been moved to FullControls.Common. This is legacy and will no longer maintained.", false)]
    public interface IDialog
    {
        /// <summary>
        /// Get the result <see cref="object"/>.
        /// </summary>
        /// <returns>Result <see cref="object"/>.</returns>
        public object GetResult();
    }
}
