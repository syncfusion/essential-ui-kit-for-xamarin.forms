using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using EssentialUIKit.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Story;

namespace EssentialUIKit.ViewModels.Article
{
    /// <summary>
    /// ViewModel for Article with comments page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ArticleWithCommentsPageViewModel : BaseViewModel
    {
        #region Fields

        private static ArticleWithCommentsPageViewModel articleWithCommentsPageViewModel;

        /// <summary>
        /// Gets or sets the article name
        /// </summary>
        private string articleName;

        /// <summary>
        /// Gets or sets the article image
        /// </summary>
        private string articleImage;

        /// <summary>
        /// Gets or sets the article sub image
        /// </summary>
        private string articleSubImage;

        /// <summary>
        /// Gets or sets article author
        /// </summary>
        private string articleAuthor;

        /// <summary>
        /// Gets or sets the article published date
        /// </summary>
        private string articleDate;

        /// <summary>
        /// Gets or sets the article content
        /// </summary>
        private string articleContent;

        /// <summary>
        /// Gets or sets the article reading time
        /// </summary>
        private string articleReadingTime;

        /// <summary>
        /// Gets or sets a value indicating whether the article is favourite or not.
        /// </summary>
        private bool isFavourite;

        /// <summary>
        /// Gets or sets a value indicating whether the article is bookmarked or not.
        /// </summary>
        private bool isBookmarked;

        /// <summary>
        /// Gets or sets the article content list.
        /// </summary>
        private ObservableCollection<Model> contentList;

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        private string subTitle;

        /// <summary>
        /// Gets or sets the article reviews
        /// </summary>
        private ObservableCollection<Review> reviews;

        private Command favouriteCommand;

        private Command bookmarkCommand;

        private Command relatedFeaturesCommand;

        private Command loadMoreCommand;

        private Command addNewCommentCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleWithCommentsPageViewModel" /> class
        /// </summary>
        static ArticleWithCommentsPageViewModel()
        {
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the value of Article with comments page view model.
        /// </summary>
        public static ArticleWithCommentsPageViewModel BindingContext =>
            articleWithCommentsPageViewModel = PopulateData<ArticleWithCommentsPageViewModel>("article.json");

        /// <summary>
        /// Gets or sets the article name
        /// </summary>
        [DataMember(Name = "articleName")]
        public string ArticleName
        {
            get
            {
                return this.articleName;
            }

            set
            {
                if (this.articleName != value)
                {
                    this.SetProperty(ref this.articleName, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the article image
        /// </summary>
        [DataMember(Name = "articleImage")]
        public string ArticleImage
        {
            get
            {
                return App.ImageServerPath + this.articleImage;
            }

            set
            {
                if (this.articleImage != value)
                {
                    this.SetProperty(ref this.articleImage, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the article sub image
        /// </summary>
        [DataMember(Name = "articleSubImage")]
        public string ArticleSubImage
        {
            get
            {
                return App.ImageServerPath + this.articleSubImage;
            }

            set
            {
                if (this.articleSubImage != value)
                {
                    this.SetProperty(ref this.articleSubImage, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the articleAuthor
        /// </summary>
        [DataMember(Name = "articleAuthor")]
        public string ArticleAuthor
        {
            get
            {
                return this.articleAuthor;
            }

            set
            {
                if (this.articleAuthor != value)
                {
                    this.SetProperty(ref this.articleAuthor, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the article reading time
        /// </summary>
        [DataMember(Name = "articleReadingTime")]
        public string ArticleReadingTime
        {
            get
            {
                return this.articleReadingTime;
            }

            set
            {
                if (this.articleReadingTime != value)
                {
                    this.SetProperty(ref this.articleReadingTime, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the article date
        /// </summary>
        [DataMember(Name = "articleDate")]
        public string ArticleDate
        {
            get
            {
                return this.articleDate;
            }

            set
            {
                if (this.articleDate != value)
                {
                    this.SetProperty(ref this.articleDate, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the article content
        /// </summary>
        [DataMember(Name = "articleContent")]
        public string ArticleContent
        {
            get
            {
                return this.articleContent;
            }

            set
            {
                if (this.articleContent != value)
                {
                    this.SetProperty(ref this.articleContent, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the article is favourite or not.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.SetProperty(ref this.isFavourite, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the article is bookmarked or not.
        /// </summary>
        public bool IsBookmarked
        {
            get
            {
                return this.isBookmarked;
            }

            set
            {
                this.SetProperty(ref this.isBookmarked, value);
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with the list view which displays the articles content list items.
        /// </summary>
        [DataMember(Name = "contentList")]
        public ObservableCollection<Model> ContentList
        {
            get
            {
                return this.contentList;
            }

            set
            {
                if (this.contentList == value)
                {
                    return;
                }

                this.SetProperty(ref this.contentList, value);
            }
        }

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        [DataMember(Name = "subTitle1")]
        public string SubTitle
        {
            get
            {
                return this.subTitle;
            }

            set
            {
                if (this.subTitle == value)
                {
                    return;
                }

                this.SetProperty(ref this.subTitle, value);
            }
        }

        /// <summary>
        /// Gets or sets the article reviews
        /// </summary>
        [DataMember(Name = "reviews")]
        public ObservableCollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                if (this.reviews == value)
                {
                    return;
                }

                this.SetProperty(ref this.reviews, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand
        {
            get
            {
                return this.favouriteCommand ?? (this.favouriteCommand = new Command(this.FavouriteButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command is executed when the book mark button is clicked.
        /// </summary>
        public Command BookmarkCommand
        {
            get
            {
                return this.bookmarkCommand ?? (this.bookmarkCommand = new Command(this.BookmarkButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command is executed when the related features item is clicked.
        /// </summary>
        public Command RelatedFeaturesCommand
        {
            get
            {
                return this.relatedFeaturesCommand ?? (this.relatedFeaturesCommand = new Command(this.RelatedFeaturesItemClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Show All button is clicked.
        /// </summary>
        public Command LoadMoreCommand
        {
            get
            {
                return this.loadMoreCommand ?? (this.loadMoreCommand = new Command(this.LoadMoreClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the add new comment is clicked.
        /// </summary>
        public Command AddNewCommentCommand
        {
            get
            {
                return this.addNewCommentCommand ?? (this.addNewCommentCommand = new Command(this.AddNewCommentClicked));
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
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            if (obj != null && (obj is ArticleWithCommentsPageViewModel))
            {
                (obj as ArticleWithCommentsPageViewModel).IsFavourite = (obj as ArticleWithCommentsPageViewModel).IsFavourite ? false : true;
            }
        }

        /// <summary>
        /// Invoked when the related features item clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void RelatedFeaturesItemClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the bookmark button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            if (obj != null && (obj is ArticleWithCommentsPageViewModel))
            {
                (obj as ArticleWithCommentsPageViewModel).IsBookmarked = (obj as ArticleWithCommentsPageViewModel).IsBookmarked ? false : true;
            }
        }

        /// <summary>
        /// Invoked when Load more button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoadMoreClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when Add new comment is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddNewCommentClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
