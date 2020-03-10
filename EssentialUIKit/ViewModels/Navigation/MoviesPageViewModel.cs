using EssentialUIKit.Models.Navigation;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{

    /// <summary>
    /// ViewModel for movies page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class MoviesPageViewModel :  BaseViewModel
    {
        #region MoviesListPage
        
        #region Fields

        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MoviesPageViewModel"/> class.
        /// </summary>
        public MoviesPageViewModel()
        {

        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets a collction of value to be displayed in movies list page.
        /// </summary>
        [DataMember(Name = "moviesPageList")]
        public ObservableCollection<Movie> MoviesList { get; set; }
 
        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the movies list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion

        #endregion

        #region MoviesPage

        #region Fields

        private Command<object> searchButtonCommand;

        private Command<object> showingNowItemTappedCommand;
        private Command<object> trailerItemTappedCommand;
        private Command<object> upcomingItemTappedCommand;

        private Command<object> showingNowViewAllCommand;
        private Command<object> trailerViewAllCommand;
        private Command<object> upcomingViewAllCommand;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a collection of value to be displayed in the rotator of movies page.
        /// </summary>
        [DataMember(Name = "rotatorMoviesList")]
        public ObservableCollection<Movie> RotatorMoviesList { get; set; }

        /// <summary>
        /// Gets or sets a collection of value to be displayed in now showing list of movies page.
        /// </summary>
        [DataMember(Name = "showingMoviesList")]
        public ObservableCollection<Movie> NowShowingMoviesList { get; set; }

        /// <summary>
        /// Gets or sets a collection of value to be displayed in the trailer list of movies page.
        /// </summary>
        [DataMember(Name = "trailerMoviesList")]
        public ObservableCollection<Movie> TrailerMoviesList { get; set; }

        /// <summary>
        /// Gets or sets a collection of value to be displayed in the upcoming movies list of movies page.
        /// </summary>
        [DataMember(Name = "upcomingMoviesList")]
        public ObservableCollection<Movie> UpcomingMoviesList { get; set; }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command that will be executed when an search button is clicked.
        /// </summary>
        public Command<object> SearchButtonCommand
        {
            get
            {
                return this.searchButtonCommand ?? (this.searchButtonCommand = new Command<object>(this.SearchButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when now showing category view all button is clicked.
        /// </summary>
        public Command<object> ShowingNowViewAllCommand
        {
            get
            {
                return this.showingNowViewAllCommand ?? (this.showingNowViewAllCommand = new Command<object>(this.ShowingNowViewAllButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when trailer category view all button is clicked.
        /// </summary>
        public Command<object> TrailerViewAllCommand
        {
            get
            {
                return this.trailerViewAllCommand ?? (this.trailerViewAllCommand = new Command<object>(this.TrailerViewAllButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when coming soon view all button is clicked.
        /// </summary>
        public Command<object> UpcomingViewAllCommand
        {
            get
            {
                return this.upcomingViewAllCommand ?? (this.upcomingViewAllCommand = new Command<object>(this.UpcomingViewAllButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when now showing item is selected.
        /// </summary>
        public Command<object> ShowingNowItemTappedCommand
        {
            get
            {
                return this.showingNowItemTappedCommand ?? (this.showingNowItemTappedCommand = new Command<object>(this.ShowingNowItemSelected));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when trailer item is clicked.
        /// </summary>
        public Command<object> TrailerItemTappedCommand
        {
            get
            {
                return this.trailerItemTappedCommand ?? (this.trailerItemTappedCommand = new Command<object>(this.TrailerItemSelected));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when coming soon item is clicked.
        /// </summary>
        public Command<object> UpcomingItemTappedCommand
        {
            get
            {
                return this.upcomingItemTappedCommand ?? (this.upcomingItemTappedCommand = new Command<object>(this.UpcomingItemSelected));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when search button is clicked from the movies page.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
        private void SearchButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when now showing category view all button is clicked.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
        private void ShowingNowViewAllButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when when trailer category view all button is clicked.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
        private void TrailerViewAllButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when coming soon category view all button is clicked.
        /// </summary>
        /// <param name="obj">Selected item from the list view.</param>
        private void UpcomingViewAllButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected from the now showing category of movies page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void ShowingNowItemSelected(object selectedItem)
        {
            // Do something
        }

        // <summary>
        /// Invoked when an item is selected from the trailer category of movies page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void TrailerItemSelected(object selectedItem)
        {
            // Do something
        }

        // <summary>
        /// Invoked when an item is selected from the coming soon category of movies page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void UpcomingItemSelected(object selectedItem)
        {
            // Do something
        }

        #endregion

        #endregion
    }
}
