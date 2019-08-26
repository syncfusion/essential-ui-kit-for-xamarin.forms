using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class is extended from Xamarin.Forms.Editor to extend the size and to remove the border for the editor control in the Android and UWP platforms.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class BorderlessEditor : Editor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorderlessEditor"/> class.
        /// </summary>
        public BorderlessEditor()
        {
            this.TextChanged += this.ExtendableEditor_TextChanged;
        }

        #region Methods

        /// <summary>
        /// Invoked when editor text is changed.
        /// </summary>
        /// <param name="sender">The editor</param>
        /// <param name="e">Text changed event args</param>
        private void ExtendableEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.InvalidateMeasure();
        }

        #endregion
    }
}