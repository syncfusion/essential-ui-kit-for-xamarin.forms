using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the items in Restaurant page based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableRestaurantPage : SearchableListView
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
                var taskInfo = obj as Models.Navigation.Restaurant;

                if ( taskInfo == null || string.IsNullOrEmpty(taskInfo.Name) || string.IsNullOrEmpty(taskInfo.Description) ||
                    string.IsNullOrEmpty(taskInfo.Offer) || string.IsNullOrEmpty(taskInfo.ItemRating))
                {
                    return false;
                }

                return taskInfo.Name.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())
                       || taskInfo.Description.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant()) ||
                       taskInfo.Offer.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant()) ||
                       taskInfo.ItemRating.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }
            return false;
        }
        #endregion
    }
}
