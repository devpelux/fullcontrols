using FullControls.Core.Services;
using System.IO;
using System.Linq;
using System.Windows;

namespace FullControls.Utils
{
    /// <summary>
    /// Provides a set of system utilities.
    /// </summary>
    public static class SystemUtil
    {
        /// <summary>
        /// Returns the current active window.
        /// </summary>
        /// <returns>Current active window, or <see langword="null"/> if there is no active window.</returns>
        public static Window? GetActiveWindow() => Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        /// <summary>
        /// Returns the current application executing file.
        /// </summary>
        /// <returns>Current application executing file.</returns>
        public static FileInfo GetExecutingFile() => new(InternalMethods.GetExecutablePath());

        /// <summary>
        /// Returns the current application executing directory.
        /// </summary>
        /// <returns>Current application executing directory.</returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static DirectoryInfo GetExecutingDirectory()
        {
            if (GetExecutingFile().Directory is DirectoryInfo dir) return dir;
            else throw new DirectoryNotFoundException("Unable to get the directory of the current application executable.");
        }
    }
}
