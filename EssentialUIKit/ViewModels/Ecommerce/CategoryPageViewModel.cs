using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.ECommerce;

namespace EssentialUIKit.ViewModels.ECommerce
{
    /// <summary>
    /// ViewModel for Category page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CategoryPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Category> categories;

        private Command itemSelectedCommand;

        private Command scrollToStartCommand;

        private Command scrollToEndCommand;

        public Command categorySelectedCommand;

        public Command expandingCommand;

        public Command notificationCommand;

        #endregion

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with StackLayout, which displays the categories using ComboBox.
        /// </summary>
        [DataMember(Name = "categories")]
        public ObservableCollection<Category> Categories
        {
            get { return this.categories; }
            set
            {
                if (this.categories == value)
                {
                    return;
                }

                this.categories = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get { return itemSelectedCommand ?? (itemSelectedCommand = new Command(this.ItemSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the ScrollToStart button is clicked.
        /// </summary>
        public Command ScrollToStartCommand
        {
            get { return scrollToStartCommand ?? (scrollToStartCommand = new Command(this.ScrollToStartClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the ScrollToEnd button is clicked.
        /// </summary>
        public Command ScrollToEndCommand
        {
            get { return scrollToEndCommand ?? (scrollToEndCommand = new Command(ScrollToEndClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Category is selected.
        /// </summary>
        public Command CategorySelectedCommand
        {
            get { return categorySelectedCommand ?? (categorySelectedCommand = new Command(CategorySelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when expander is expanded.
        /// </summary>
        public Command ExpandingCommand
        {
            get { return expandingCommand ?? (expandingCommand = new Command(this.ExpanderClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Notification button is clicked.
        /// </summary>
        public Command NotificationCommand
        {
            get { return notificationCommand ?? (notificationCommand = new Command(this.NotificationClicked)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void ItemSelected(object attachedObject)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void ScrollToStartClicked(object attachedObject)
        {
            if (!(attachedObject is SfListView listView))
            {
                return;
            }

            var scrollRow = listView.GetVisualContainer()?.ScrollRows;
            var firstVisibleIndex = (int) scrollRow?.ScrollLineIndex;
            var totalItemsCount = listView.DataSource.DisplayItems.Count;

            int scrollToIndex;
            if (firstVisibleIndex > 0 && firstVisibleIndex < totalItemsCount - 1)
            {
                scrollToIndex = firstVisibleIndex - 1;
            }
            else
            {
                scrollToIndex = 0;
            }

            listView.LayoutManager.ScrollToRowIndex(scrollToIndex, Syncfusion.ListView.XForms.ScrollToPosition.Center,
                true);
        }

        /// <summary>
        /// Invoked when the items are sorted.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private static void ScrollToEndClicked(object attachedObject)
        {
            if (!(attachedObject is SfListView listView))
            {
                return;
            }

            var scrollRow = listView.GetVisualContainer()?.ScrollRows;
            var lastVisibleIndex = (int) scrollRow?.LastBodyVisibleLineIndex;
            var totalItemsCount = listView.DataSource.DisplayItems.Count;

            int scrollToIndex;
            if (lastVisibleIndex >= 0 && lastVisibleIndex < totalItemsCount - 1)
            {
                scrollToIndex = lastVisibleIndex + 1;
            }
            else
            {
                scrollToIndex = totalItemsCount - 1;
            }

            listView.LayoutManager.ScrollToRowIndex(scrollToIndex, Syncfusion.ListView.XForms.ScrollToPosition.Center,
                true);
        }

        /// <summary>
        /// Invoked when the Category is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private static async void CategorySelected(object obj)
        {
            //Do Something
        }

        /// <summary>
        /// Invoked when the expander is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ExpanderClicked(object obj)
        {
            var objects = obj as List<object>;
            var category = objects[0] as Category;
            var listView = objects[1] as SfListView;

            if (listView == null)
            {
                return;
            }

            var itemIndex = listView.DataSource.DisplayItems.IndexOf(category);
            var scrollIndex = itemIndex + category.SubCategories.Count;
            //Expand and bring the item in the view.
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(100);
                listView.LayoutManager.ScrollToRowIndex(scrollIndex, Syncfusion.ListView.XForms.ScrollToPosition.End,
                    true);
            });
        }

        /// <summary>
        /// Invoked when the notification button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void NotificationClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}