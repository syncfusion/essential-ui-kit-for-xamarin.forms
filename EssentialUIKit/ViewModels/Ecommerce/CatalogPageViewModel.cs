using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Syncfusion.ListView.XForms;
using EssentialUIKit.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.ECommerce
{
    /// <summary>
    /// ViewModel for catalog page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CatalogPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Category> filterOptions;

        private ObservableCollection<string> sortOptions;

        private Command addFavouriteCommand;

        private Command itemSelectedCommand;

        private Command sortCommand;

        private Command filterCommand;

        private Command addToCartCommand;

        private Command expandingCommand;

        private Command cardItemCommand;

        private string cartItemCount;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CatalogPageViewModel" /> class.
        /// </summary>
        public CatalogPageViewModel()
        {
            this.FilterOptions = new ObservableCollection<Category>
            {
                new Category
                {
                    Name = "Gender",
                    SubCategories = new List<string>
                    {
                        "Men",
                        "Women"
                    }
                },
                new Category
                {
                    Name = "Brand",
                    SubCategories = new List<string>
                    {
                        "Brand A",
                        "Brand B"
                    }
                },
                new Category
                {
                    Name = "Categories",
                    SubCategories = new List<string>
                    {
                        "Category A",
                        "Category B"
                    }
                },
                new Category
                {
                    Name = "Color",
                    SubCategories = new List<string>
                    {
                        "Maroon",
                        "Pink"
                    }
                },
                new Category
                {
                    Name = "Price",
                    SubCategories = new List<string>
                    {
                        "Above 3000",
                        "1000 to 3000",
                        "Below 1000"
                    }
                },
                new Category
                {
                    Name = "Size",
                    SubCategories = new List<string>
                    {
                        "S", "M", "L", "XL", "XXL"
                    }
                },
                new Category
                {
                    Name = "Patterns",
                    SubCategories = new List<string>
                    {
                        "Pattern 1", "Pattern 2"
                    }
                },
                new Category
                {
                    Name = "Offers",
                    SubCategories = new List<string>
                    {
                        "Buy 1 Get 1", "Buy 1 Get 2"
                    }
                },
                new Category
                {
                    Name = "Coupons",
                    SubCategories = new List<string>
                    {
                        "Coupon 1", "Coupon 2"
                    }
                },
            };

            this.SortOptions = new ObservableCollection<string>
            {
                "New Arrivals",
                "Price - high to low",
                "Price - Low to High",
                "Popularity",
                "Discount"
            };
        }

        #endregion

        #region Event

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the item details in tile.
        /// </summary>
        [DataMember(Name="products")]
        public ObservableCollection<Product> Products
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the filter options.
        /// </summary>
        public ObservableCollection<Category> FilterOptions
        {
            get
            {
                return this.filterOptions;
            }

            set
            {
                if (this.filterOptions == value)
                {
                    return;
                }

                this.filterOptions = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with a list view, which displays the sort details.
        /// </summary>
        public ObservableCollection<string> SortOptions
        {
            get
            {
                return this.sortOptions;
            }

            set
            {
                if (this.sortOptions == value)
                {
                    return;
                }

                this.sortOptions = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the cart items count.
        /// </summary>
        public string CartItemCount
        {
            get
            {
                return this.cartItemCount;
            }
            set
            {
                this.cartItemCount = value;
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
            get { return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the sort button is clicked.
        /// </summary>
        public Command SortCommand
        {
            get { return this.sortCommand ?? (this.sortCommand = new Command(this.SortClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the filter button is clicked.
        /// </summary>
        public Command FilterCommand
        {
            get { return this.filterCommand ?? (this.filterCommand = new Command(this.FilterClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand
        {
            get
            {
                return this.addFavouriteCommand ?? (this.addFavouriteCommand = new Command(this.AddFavouriteClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand
        {
            get { return this.addToCartCommand ?? (this.addToCartCommand = new Command(this.AddToCartClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when expander is expanded.
        /// </summary>
        public Command ExpandingCommand
        {
            get { return this.expandingCommand ?? (this.expandingCommand = new Command(this.ExpanderClicked)); }
        }

        /// <summary>
        /// Gets or sets the command will be executed when the cart icon button has been clicked.
        /// </summary>
        public Command CardItemCommand
        {
            get { return this.cardItemCommand ?? (this.cardItemCommand = new Command(this.CartClicked)); }
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
        /// Invoked when the items are sorted.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void SortClicked(object attachedObject)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the filter button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FilterClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the favourite button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddFavouriteClicked(object obj)
        {
            if (obj is Product product)
                product.IsFavourite = !product.IsFavourite;
        }

        /// <summary>
        /// Invoked when the cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddToCartClicked(object obj)
        {
            // Do something
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
                await System.Threading.Tasks.Task.Delay(100);
                listView.LayoutManager.ScrollToRowIndex(scrollIndex, Syncfusion.ListView.XForms.ScrollToPosition.End, true);
            });
        }

        /// <summary>
        /// Invoked when cart icon button is clicked.
        /// </summary>
        /// <param name="obj"></param>
        private void CartClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}