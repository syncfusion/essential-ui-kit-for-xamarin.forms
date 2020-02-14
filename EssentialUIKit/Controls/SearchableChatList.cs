using EssentialUIKit.Models.Chat;
using Syncfusion.ListView.XForms;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the ListViewItem based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableChatList : SearchableListView
    {
        #region Contructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchableChatList" /> class.
        /// </summary>
        public SearchableChatList()
        {
            this.SelectionChanged -= this.CustomListView_SelectionChanged;
            this.SelectionChanged += this.CustomListView_SelectionChanged;
        }

        #endregion

        #region Method

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public override bool FilterContacts(object obj)
        {
            if (base.FilterContacts(obj))
            {
                var taskInfo = obj as ChatDetail;
                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.SenderName) || string.IsNullOrEmpty(taskInfo.Message))
                {
                    return false;
                }
                var message = taskInfo.Message;
                if (taskInfo.MessageType != "Text")
                {
                    message = string.Empty;
                }

                return taskInfo.SenderName.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())
                       || message.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }

            return false;
        }

        /// <summary>
        /// Invoked when list view selection items are changed.
        /// </summary>
        /// <param name="sender">The ListView</param>
        /// <param name="e">Item selection changed event args</param>
        private async void CustomListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            this.SelectionBackgroundColor = (Color) retVal;
            await Task.Delay(100);
            this.SelectionBackgroundColor = Color.Transparent;
            this.SelectedItems.Clear();
        }

        #endregion
    }
}