using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Navigation;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// Viewmodel for the Navigation list with tile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NavigationTileViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NavigationTileViewModel"/> class.
        /// </summary>
        public NavigationTileViewModel()
        {
            this.ItemSelectedCommand = new Command<object>(this.NavigateToNextPage);

            this.NavigationList = new ObservableCollection<NavigationTileModel>
            {
                new NavigationTileModel
                {
                    ItemName = "S’mores",
                    ItemDescription = "We slow-roast our marshmallows for the perfect s’more",
                    ItemImage = App.BaseImageUrl + "Recipe17.png",
                    ItemRating = 4.8
                },
                new NavigationTileModel
                {
                    ItemName = "Honey Chicken",
                    ItemDescription = "Roasted vegetables top this honey chicken",
                    ItemImage = App.BaseImageUrl + "Recipe7.png",
                    ItemRating = 4.5
                },
                new NavigationTileModel
                {
                    ItemName = "Macarons",
                    ItemDescription = "Eight colorful flavors of macarons, fresh daily",
                    ItemImage = App.BaseImageUrl + "Recipe3.png",
                    ItemRating = 4.2
                },
                new NavigationTileModel
                {
                    ItemName = "Red Velvet Cake",
                    ItemDescription =
                        "Classic red velvet cake with rich, cream cheese frosting and dark chocolate shavings",
                    ItemImage = App.BaseImageUrl + "Recipe4.png",
                    ItemRating = 4.6
                },
                new NavigationTileModel
                {
                    ItemName = "Garlic French Fries",
                    ItemDescription =
                        "Piping-hot French fries slathered in garlic and sprinkled with parsley and parmesan",
                    ItemImage = App.BaseImageUrl + "Recipe12.png",
                    ItemRating = 4.5
                },
                new NavigationTileModel
                {
                    ItemName = "Macarons",
                    ItemDescription = "Eight colorful flavors of macarons, fresh daily",
                    ItemImage = App.BaseImageUrl + "Recipe3.png",
                    ItemRating = 4.2
                }
            };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Navigation list page.
        /// </summary>
        public ObservableCollection<NavigationTileModel> NavigationList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the Navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}