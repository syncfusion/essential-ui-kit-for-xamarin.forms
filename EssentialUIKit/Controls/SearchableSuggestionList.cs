using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the items in suggestion page based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableSuggestionList : SearchableListView
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
                var taskInfo = obj as Models.Navigation.Suggestion;
                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.SuggestionName) || string.IsNullOrEmpty(taskInfo.Id))
                {
                    return false;
                }

                return taskInfo.SuggestionName.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())
                       || taskInfo.Id.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }
            return false;
        }

        #endregion
    }
}
