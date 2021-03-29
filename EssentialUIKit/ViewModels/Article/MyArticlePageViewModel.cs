using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Story;

namespace EssentialUIKit.ViewModels.Article
{
    /// <summary>
    /// ViewModel for My Article page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class MyArticlePageViewModel : BaseViewModel
    {
        #region Fields        

        private static MyArticlePageViewModel myArticlePageViewModel;

        /// <summary>
        /// Gets or sets the article list.
        /// </summary>
        private ObservableCollection<Model> articleList;

        private Command searchCommand;

        private Command articleListItemSelectionCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MyArticlePageViewModel" /> class
        /// </summary>
        static MyArticlePageViewModel()
        {
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the value of My aricle page view model.
        /// </summary>
        public static MyArticlePageViewModel BindingContext =>
            myArticlePageViewModel = PopulateData<MyArticlePageViewModel>("article.json");

        /// <summary>
        /// Gets or sets the property has been bound with the list view which displays the my article list items.
        /// </summary>
        [DataMember(Name = "articleList")]
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

                this.SetProperty(ref this.articleList, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the search button is clicked.
        /// </summary>
        public Command SearchCommand
        {
            get
            {
                return this.searchCommand ?? (this.searchCommand = new Command(this.SearchButtonClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command is executed when the article list item is clicked.
        /// </summary>
        public Command ArticleListItemSelectionCommand
        {
            get
            {
                return this.articleListItemSelectionCommand ?? (this.articleListItemSelectionCommand = new Command(this.ArticleListItemClicked));
            }
        }

        #endregion

        #region Methods

        // Populates the data for view model from json file.
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
