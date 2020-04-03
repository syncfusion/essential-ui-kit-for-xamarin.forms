using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Navigation;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class extends the behavior of the SearchableListView control to filter the ListViewItem based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableFileExploreList : SearchableListView
    {
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
                var taskInfo = obj as File;
                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.FolderName) || string.IsNullOrEmpty(taskInfo.Items) 
                    || string.IsNullOrEmpty(taskInfo.DateTime))
                {
                    return false;
                }

                return taskInfo.FolderName.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())
                    || taskInfo.Items.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant()) 
                    || taskInfo.DateTime.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }

            return false;
        }

        #endregion
    }
}