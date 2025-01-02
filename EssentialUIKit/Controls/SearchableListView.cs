using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Controls
{
    /// <summary>
    /// This class extends the behavior of the SfListView control to filter the ListViewItem based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableListView : SfListView
    {
        #region Field

        /// <summary>
        /// Gets or sets the text value used to search.
        /// </summary>
        public static readonly BindableProperty SearchTextProperty = 
            BindableProperty.Create(nameof(SearchText), typeof(string), typeof(SearchableListView), null, BindingMode.Default, null, OnSearchTextChanged);

        /// <summary>
        /// Gets or sets the text value used to search.
        /// </summary>
        private string searchText;

        #endregion
        
        #region Property

        /// <summary>
        /// Gets or sets the text value used to search.
        /// </summary>
        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { this.SetValue(SearchTextProperty, value); }
        }

        #endregion

        #region Method

        /// <summary>
        /// Invoked when the search text is changed.
        /// </summary>
        /// <param name="bindable">The SfListView</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private static void OnSearchTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var listView = bindable as SearchableListView;
            if (newValue != null && listView.DataSource != null)
            {
                listView.searchText = (string)newValue;
                listView.DataSource.Filter = listView.FilterContacts;
                listView.DataSource.RefreshFilter();
            }

            listView.RefreshView();
        }
        
        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public virtual bool FilterContacts(object obj)
        {
            if (this.SearchText == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}