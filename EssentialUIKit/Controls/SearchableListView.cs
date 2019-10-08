using System.Threading.Tasks;
using EssentialUIKit.Models.Chat;
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
            BindableProperty.Create("SearchText", typeof(string), typeof(SearchableListView), null, BindingMode.Default, null, OnSearchTextChanged);

        /// <summary>
        /// Gets or sets the text value used to search.
        /// </summary>
        private string searchText;

        #endregion

        #region Contructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchableListView" /> class.
        /// </summary>
        public SearchableListView()
        {
            this.SelectionChanged -= this.CustomListView_SelectionChanged;
            this.SelectionChanged += this.CustomListView_SelectionChanged;
        }

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
        /// Invoked when list view selection items are changed.
        /// </summary>
        /// <param name="sender">The ListView</param>
        /// <param name="e">Item selection changed event args</param>
        private async void CustomListView_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (Application.Current.Resources.TryGetValue("Gray-100", out var retVal))
            {
            }

            this.SelectionBackgroundColor = (Color)retVal;
            await Task.Delay(100);
            this.SelectionBackgroundColor = Color.Transparent;
            this.SelectedItems.Clear();
        }

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        private bool FilterContacts(object obj)
        {
            var taskInfo = obj as ChatDetail;
            var message = taskInfo.Message;
            if (taskInfo.MessageType != "Text")
            {
                message = string.Empty;
            }

            if (this.searchText == null || taskInfo.SenderName == null || message == null)
            {
                return true;
            }

            return taskInfo.SenderName.ToLower().Contains(this.searchText.ToLower())
                   || message.ToLower().Contains(this.searchText.ToLower());
        }

        #endregion
    }
}