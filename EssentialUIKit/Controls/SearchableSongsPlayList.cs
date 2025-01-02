using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the items in Songs PlayList page based on text.
    /// </summary>
    [Preserve(AllMembers = true)]

    public class SearchableSongsPlayList : SearchableListView
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
                var taskInfo = obj as Models.Navigation.Song;

                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.SongName) || string.IsNullOrEmpty(taskInfo.Composer))
                {
                    return false;
                }

                return taskInfo.SongName.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())
                       || taskInfo.Composer.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }
            return false;
        }
        #endregion
    }
}
