using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace FullControls.Extra.Extensions
{
    /// <summary>
    /// Provides a set of <see cref="Storyboard"/> extensions.
    /// </summary>
    public static class StoryboardExtensions
    {
        /// <summary>
        /// Applies the animations associated with this <see cref="Storyboard"/> to their targets and initiates them asyncronously.
        /// </summary>
        /// <param name="storyboard">Current storyboard.</param>
        public static Task BeginAsync(this Storyboard storyboard)
        {
            TaskCompletionSource<bool> task = new();
            if (storyboard == null) task.SetException(new ArgumentNullException(nameof(storyboard), "Storyboard is null."));
            else
            {
                void onCurrentStateInvalidated(object s, EventArgs e)
                {
                    if (storyboard.GetCurrentState() != ClockState.Active) task.SetResult(true);
                }

                storyboard.CurrentStateInvalidated += onCurrentStateInvalidated;
                storyboard.Begin();
            }
            return task.Task;
        }
    }
}
