using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Story;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for Article Detail page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ArticleDetailPageViewModel : BaseViewModel
    {
        #region Fields

        private static ArticleDetailPageViewModel articleDetailPageViewModel;

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
        /// Gets or sets the arrticle published date
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
        /// Gets or sets the related stories.
        /// </summary>
        private ObservableCollection<Model> relatedStories;

        /// <summary>
        /// Gets or sets the article content list.
        /// </summary>
        private ObservableCollection<Model> contentList;

        /// <summary>
        /// Gets or sets the articlesub title
        /// </summary>
        private string subTitle1;

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        private string subTitle2;

        private Command favouriteCommand;

        private Command bookmarkCommand;

        private Command itemSelectedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleDetailPageViewModel" /> class
        /// </summary>
        public ArticleDetailPageViewModel()
        {
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the value of article detail page view model.
        /// </summary>
        public static ArticleDetailPageViewModel BindingContext =>
            articleDetailPageViewModel = PopulateData<ArticleDetailPageViewModel>("detail.json");

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
        /// Gets or sets the property has been bound with the list view which displays the articles related stories items.
        /// </summary>
        [DataMember(Name = "relatedStories")]
        public ObservableCollection<Model> RelatedStories
        {
            get
            {
                return this.relatedStories;
            }

            set
            {
                if (this.relatedStories == value)
                {
                    return;
                }

                this.SetProperty(ref this.relatedStories, value);
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
        public string SubTitle1
        {
            get
            {
                return this.subTitle1;
            }

            set
            {
                if (this.subTitle1 == value)
                {
                    return;
                }

                this.SetProperty(ref this.subTitle1, value);
            }
        }

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        [DataMember(Name = "subTitle2")]
        public string SubTitle2
        {
            get
            {
                return this.subTitle2;
            }

            set
            {
                if (this.subTitle2 == value)
                {
                    return;
                }

                this.SetProperty(ref this.subTitle2, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand
        {
            get
            {
                return this.favouriteCommand ?? (this.favouriteCommand = new Command(this.FavouriteButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the book mark button is clicked.
        /// </summary>
        public Command BookmarkCommand
        {
            get
            {
                return this.bookmarkCommand ?? (this.bookmarkCommand = new Command(this.BookmarkButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command is executed when the related features item is clicked.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get
            {
                return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemClicked));
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
            if (obj != null && (obj is ArticleDetailPageViewModel))
            {
                (obj as ArticleDetailPageViewModel).IsFavourite = (obj as ArticleDetailPageViewModel).IsFavourite ? false : true;
            }
        }

        /// <summary>
        /// Invoked when the related features item clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void ItemClicked(object obj)
        {
            // Do something
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
            else if (obj != null && (obj is ArticleDetailPageViewModel))
            {
                (obj as ArticleDetailPageViewModel).IsBookmarked = (obj as ArticleDetailPageViewModel).IsBookmarked ? false : true;
            }
        }

        #endregion
    }
}
