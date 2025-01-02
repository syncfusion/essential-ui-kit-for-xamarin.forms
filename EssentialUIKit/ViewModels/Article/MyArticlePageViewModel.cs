using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Article;

namespace EssentialUIKit.ViewModels.Article
{
    /// <summary>
    /// ViewModel for My Article page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class MyArticlePageViewModel : BaseViewModel
    {
        #region Fields        
        
        /// <summary>
        /// Gets or sets the article list.
        /// </summary>
        private ObservableCollection<Model> articleList;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MyArticlePageViewModel" /> class
        /// </summary>
        public MyArticlePageViewModel()
        {
            this.articleList = new ObservableCollection<Model>
            {
                new Model { ImagePath = App.BaseImageUrl + "Book1.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book2.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book3.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book4.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book5.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book6.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book7.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book8.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book9.png" },
                new Model { ImagePath = App.BaseImageUrl + "Book10.png" },
            };
            
            this.SearchCommand = new Command(this.SearchButtonClicked);
            this.ArticleListIteSelectionCommand = new Command(this.ArticleListItemClicked);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property has been bound with the list view which displays the my article list items.
        /// </summary>
        public ObservableCollection<Model> ArticleList
        {
            get
            {
                return this.articleList;
            }

            set
            {
                if (this.articleList == value)
                {
                    return;
                }

                this.articleList = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the search button is clicked.
        /// </summary>
        public Command SearchCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the article list item is clicked.
        /// </summary>
        public Command ArticleListIteSelectionCommand { get; set; }
        
        #endregion

        #region Methods
        
        /// <summary>
        /// Invoked when the article list item clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void ArticleListItemClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the search button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void SearchButtonClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
