using EssentialUIKit.AppLayout.Models;
using EssentialUIKit.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.AppLayout.ViewModels
{
    [Preserve(AllMembers = true)]
    [QueryProperty("QueryData", "data1")]
    public class TemplatePageViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        private Category selectedCategory;

        private bool isDarkTheme;
        private bool isItemsGridView;
        private bool isItemsListView = true;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        public Category SelectedCategory
        {
            get => this.selectedCategory;
            set
            {
                if (TemplatePageViewModel.Equals(value, this.selectedCategory))
                {
                    return;
                }

                this.SetProperty(ref this.selectedCategory, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether dark theme applied or not.
        /// </summary>
        public bool IsDarkTheme
        {
            get => this.isDarkTheme;
            set
            {
                this.SetProperty(ref this.isDarkTheme, value);
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sub category items are in grid view or not.
        /// </summary>
        public bool IsItemsGridView
        {
            get => this.isItemsGridView;
            set
            {
                AppSettings.Instance.IsGridView = value;
                this.IsItemsListView = !value;
                this.SetProperty(ref this.isItemsGridView, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sub category items are in list view or not.
        /// </summary>
        public bool IsItemsListView
        {
            get => this.isItemsListView;
            set
            {
                this.SetProperty(ref this.isItemsListView, value);
            }
        }

        #endregion
    }
}
