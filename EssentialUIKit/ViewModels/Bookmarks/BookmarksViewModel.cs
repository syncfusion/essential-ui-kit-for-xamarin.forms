using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Story;

namespace EssentialUIKit.ViewModels.Bookmarks
{
    /// <summary>
    /// ViewModel for Article bookmark page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BookmarksViewModel : BaseViewModel
    {
        #region Fields

        private static BookmarksViewModel bookmarksViewModel;

        private ObservableCollection<Model> latestStories;

        private Command bookmarkCommand;

        private Command itemSelectedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="BookmarksViewModel" /> class.
        /// </summary>
        static BookmarksViewModel()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of Bookmark page view model.
        /// </summary>
        public static BookmarksViewModel BindingContext =>
            bookmarksViewModel = PopulateData<BookmarksViewModel>("bookmark.json");

        /// <summary>
        /// Gets or sets the property that has been bound with the list view, which displays the articles' latest stories items.
        /// </summary>
        [DataMember(Name = "latestStories")]
        public ObservableCollection<Model> LatestStories
        {
            get { return this.latestStories; }

            set
            {
                if (this.latestStories == value)
                {
                    return;
                }

                this.SetProperty(ref this.latestStories, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the bookmark button is clicked.
        /// </summary>
        public Command BookmarkCommand
        {
            get
            {
                return this.bookmarkCommand ?? (this.bookmarkCommand = new Command(this.BookmarkButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected));
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
        /// Invoked when the bookmark button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            if (obj is Model article)
            {
                this.LatestStories.Remove(article);
            }
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private void ItemSelected(object obj)
        {
            // Do something
        }

        #endregion
    }
}