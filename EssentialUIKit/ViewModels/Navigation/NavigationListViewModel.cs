using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models.Navigation;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for the Navigation list with cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NavigationListViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NavigationListViewModel"/> class.
        /// </summary>
        public NavigationListViewModel()
        {
            this.ItemTappedCommand = new Command<object>(this.NavigateToNextPage);

            this.NavigationList = new ObservableCollection<NavigationListModel>
            {
                new NavigationListModel
                {
                    ItemName = "Hamburger",
                    ItemDescription = "Classic hamburger with Angus beef grilled to perfection",
                    ItemImage = App.BaseImageUrl + "Recipe19.png",
                    ItemRating = 4.5
                },
                new NavigationListModel
                {
                    ItemName = "Black Bean Burger",
                    ItemDescription = "Our signature black bean burger on a whole-grain bun",
                    ItemImage = App.BaseImageUrl + "Recipe8.png",
                    ItemRating = 4.7
                },
                new NavigationListModel
                {
                    ItemName = "Macarons",
                    ItemDescription = "Eight colorful flavors of macarons, fresh daily",
                    ItemImage = App.BaseImageUrl + "Recipe3.png",
                    ItemRating = 4.3
                },
                new NavigationListModel
                {
                    ItemName = "Egg on Toast",
                    ItemDescription = "A sunny-side up egg on toast, just like grandma used to make",
                    ItemImage = App.BaseImageUrl + "Recipe9.png",
                    ItemRating = 4.5
                },
                new NavigationListModel
                {
                    ItemName = "Chocolate Caramel Cake",
                    ItemDescription = "Rich dark chocolate cake layered with caramel icing",
                    ItemImage = App.BaseImageUrl + "Recipe13.png",
                    ItemRating = 4.8
                },
                new NavigationListModel
                {
                    ItemName = "Macarons",
                    ItemDescription = "Eight colorful flavors of macarons, fresh daily",
                    ItemImage = App.BaseImageUrl + "Recipe3.png",
                    ItemRating = 4.3
                },
            };
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand { get; set; }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Navigation list page.
        /// </summary>
        public ObservableCollection<NavigationListModel> NavigationList { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion
    }
}