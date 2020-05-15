using Xamarin.Forms;
using System.Collections.ObjectModel;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Article;

namespace EssentialUIKit.ViewModels.Catalog
{
    /// <summary>
    /// ViewModel for Article card type page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class ArticleCardViewModel : BaseViewModel
    {
        #region Fields

     

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a collction of value to be displayed in articles card page.
        /// </summary>
        public ObservableCollection<Model> Articles { get; set; }

       

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="ArticleCardViewModel" />
        /// </summary>
        public ArticleCardViewModel()
        {
            
            this.BookmarkCommand = new Command(this.BookmarkButtonClicked);
            this.AddFavouriteCommand = new Command(this.FavouriteButtonClicked);
            this.ShareCommand = new Command(this.ShareButtonClicked);
            this.ItemTappedCommand = new Command(this.NavigateToNextPage);

            this.Articles = new ObservableCollection<Model>()
            {
                new Model
                {
                    Name = "Better Brainstorming by Hand",
                    Author = "John Doe",
                    Date = "Apr 16",
                    AverageReadingTime = "5 min read",
                    ImagePath= App.BaseImageUrl + "ArticleParallaxHeaderImage.png",
                    BookmarkedCount= 157,
                    FavouritesCount= 100,
                    SharedCount = 170
                },
                new Model
                {
                    Name = "Holistic Approach to UI Design",
                    Author = "John Doe",
                    Date = "Apr 28",
                    AverageReadingTime = "5 min read",
                    ImagePath= App.BaseImageUrl + "Event-Image.png",
                    BookmarkedCount= 123,
                    FavouritesCount= 60,
                    SharedCount = 100
                },
                new Model
                {
                    Name = "Learning to Reset",
                    Author = "John Doe",
                    Date = "Aug 16",
                    AverageReadingTime = "5 min read",
                    ImagePath= App.BaseImageUrl + "ArticleImage2.png",
                    BookmarkedCount= 213,
                    FavouritesCount= 250,
                    SharedCount = 210
                },
                new Model
                {
                    Name = "Music",
                    Author = "John Doe",
                    Date = "Aug 25",
                    AverageReadingTime = "5 min read",
                    ImagePath= App.BaseImageUrl + "ArticleImage7.jpg",
                    BookmarkedCount= 263,
                    FavouritesCount= 350,
                    SharedCount = 300
                },
                new Model
                {
                    Name = "Guiding Your Flock to Success",
                    Author = "John Doe",
                    Date = "Apr 16",
                    ImagePath= App.BaseImageUrl + "ArticleImage4.png",
                    AverageReadingTime = "5 min read",
                    BookmarkedCount= 113,
                    FavouritesCount= 90,
                    SharedCount = 190
                },
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the articles card list page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            if (obj != null && (obj is Model))
            {
                (obj as Model).IsFavourite = (obj as Model).IsFavourite ? false : true;
            }
            else
            {
                var favouriteButton = obj as SfButton;
                if (favouriteButton != null)
                {
                    favouriteButton.Text = (favouriteButton.Text == "\ue701") ? "\ue732" : "\ue701";
                }
            }
        }

        /// <summary>
        /// Invoked when the bookmark button clicked
        /// </summary>
        /// <param name="obj"></param>
        public void BookmarkButtonClicked(object obj)
        {
            if (obj != null && (obj is Model))
            {
                (obj as Model).IsBookmarked = (obj as Model).IsBookmarked ? false : true;
            }
            else
            {
                var bookmarkButton = obj as SfButton;
                if (bookmarkButton != null)
                {
                    bookmarkButton.Text = (bookmarkButton.Text == "\ue72f") ? "\ue734" : "\ue72f";
                }
            }
        }

        /// <summary>
        /// Invoked when the share button clicked
        /// </summary>
        /// <param name="obj"></param>
        private void ShareButtonClicked(object obj)
        {
            // Do Something.
        }
        #endregion

        #region commands

        /// <summary>
        /// Gets or sets the command is executed when the bookmark button is clicked.
        /// </summary>
        public Command BookmarkCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the share button is clicked.
        /// </summary>
        public Command ShareCommand { get; set; }
     
        /// <summary>
        /// Gets or sets the command is executed when the item  is clicked.
        /// </summary>
        public Command ItemTappedCommand { get; set; }

        #endregion
    }
}
