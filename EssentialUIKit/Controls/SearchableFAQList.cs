using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the items in FAQ list based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableFAQList : SearchableListView
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
                var taskInfo = obj as Models.Navigation.FAQ;

                if(taskInfo == null || string.IsNullOrEmpty(taskInfo.Question))
                {
                    return false;
                }

                return taskInfo.Question.ToUpperInvariant().Contains(SearchText.ToUpperInvariant()) ||
                    taskInfo.Answer.Exists(item => item.ToUpperInvariant().Contains(SearchText.ToUpperInvariant()));
            }

            return false;
        }
        
        #endregion
    }
}
