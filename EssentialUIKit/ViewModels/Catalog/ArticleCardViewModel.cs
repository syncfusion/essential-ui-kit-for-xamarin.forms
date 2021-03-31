using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Story;

namespace EssentialUIKit.ViewModels.Catalog
{
    /// <summary>
    /// ViewModel for Article card type page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ArticleCardViewModel : BaseViewModel
    {
        #region fields

        private static ArticleCardViewModel articleCardViewModel;

        private Command bookmarkCommand;

        private Command addFavouriteCommand;

        private Command shareCommand;

        private Command itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ArticleCardViewModel" />
        /// </summary>
        public ArticleCardViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of article card view model.
        /// </summary>
        public static ArticleCardViewModel BindingContext =>
            articleCardViewModel = PopulateData<ArticleCardViewModel>("catalog.json");

        /// <summary>
        /// Gets or sets a collction of value to be displayed in articles card page.
        /// </summary>
        [DataMember(Name = "articles")]
        public ObservableCollection<Model> Articles { get; set; }

        #endregion

        #region commands

        /// <summary>
        /// Gets the command is executed when the bookmark button is clicked.
        /// </summary>
        public Command BookmarkCommand
        {
            get
            {
                return this.bookmarkCommand ?? (this.bookmarkCommand = new Command(this.BookmarkButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand
        {
            get
            {
                return this.addFavouriteCommand ?? (this.addFavouriteCommand = new Command(this.FavouriteButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the share button is clicked.
        /// </summary>
        public Command ShareCommand
        {
            get
            {
                return this.shareCommand ?? (this.shareCommand = new Command(this.ShareButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the item  is clicked.
        /// </summary>
        public Command ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command(this.NavigateToNextPage));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "EssentialUIKit.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

        /// <summary>
        /// Invoked when an item is selected from the articles card list page.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
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
        }

        /// <summary>
        /// Invoked when the bookmark button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            if (obj != null && (obj is Model))
            {
                (obj as Model).IsBookmarked = (obj as Model).IsBookmarked ? false : true;
            }
        }

        /// <summary>
        /// Invoked when the share button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void ShareButtonClicked(object obj)
        {
            // Do Something.
        }

        #endregion
    }
}
