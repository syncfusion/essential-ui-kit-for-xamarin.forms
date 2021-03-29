using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Catalog.Travel;

namespace EssentialUIKit.ViewModels.Catalog
{
    /// <summary>
    /// ViewModel for navigation travel page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class NavigationTravelPageViewModel : BaseViewModel
    {
        #region Fields

        private static NavigationTravelPageViewModel navigationTravelPageViewModel;

        private ObservableCollection<Model> travelPlaces;

        private ObservableCollection<Model> topDestinations;

        private ObservableCollection<Model> bestPlaces;

        private Command addFavouriteCommand;

        private Command selectionCommand;

        private int selectedIndex;

        private Command viewAllCommand;

        private Command travelPlacesCommand;

        private Command topDestinationsCommand;

        private Command bestPlacesCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NavigationTravelPageViewModel" /> class.
        /// </summary>
        static NavigationTravelPageViewModel()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of navigation travel page view model.
        /// </summary>
        public static NavigationTravelPageViewModel BindingContext =>
            navigationTravelPageViewModel = PopulateData<NavigationTravelPageViewModel>("catalog.json");

        /// <summary>
        /// Gets or sets the property that has been bound with the rotator view, which displays the travel places and details.
        /// </summary>
        [DataMember(Name = "travelPlacesList")]
        public ObservableCollection<Model> TravelPlaces
        {
            get
            {
                return this.travelPlaces;
            }

            set
            {
                if (this.travelPlaces == value)
                {
                    return;
                }

                this.SetProperty(ref this.travelPlaces, value);
            }
        }

        /// <summary>
        /// Gets or sets the property which displays top destinations, details and price.
        /// </summary>
        [DataMember(Name = "topDestinationsList")]
        public ObservableCollection<Model> TopDestinations
        {
            get
            {
                return this.topDestinations;
            }

            set
            {
                if (this.topDestinations == value)
                {
                    return;
                }

                this.SetProperty(ref this.topDestinations, value);
            }
        }

        /// <summary>
        /// Gets or sets the property which displays the names and images of best places.
        /// </summary>
        [DataMember(Name = "bestPlacesList")]
        public ObservableCollection<Model> BestPlaces
        {
            get
            {
                return this.bestPlaces;
            }

            set
            {
                if (this.bestPlaces == value)
                {
                    return;
                }

                this.SetProperty(ref this.bestPlaces, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected index of the rotator.
        /// </summary>
        public int SelectedIndex
        {
            get { return this.selectedIndex; }

            set
            {
                if (this.selectedIndex == value)
                {
                    return;
                }

                this.SetProperty(ref this.selectedIndex, value);
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will executed when the travel places item is clicked.
        /// </summary>
        public Command TravelPlacesCommand
        {
            get
            {
                return this.travelPlacesCommand ?? (this.travelPlacesCommand = new Command(this.TravelPlacesClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will executed when the top destinations item is clicked.
        /// </summary>
        public Command TopDestinationsCommand
        {
            get
            {
                return this.topDestinationsCommand ?? (this.topDestinationsCommand = new Command(this.TopDestinationsClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will executed when the best places item is clicked.
        /// </summary>
        public Command BestPlacesCommand
        {
            get
            {
                return this.bestPlacesCommand ?? (this.bestPlacesCommand = new Command(this.BestPlacesClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand
        {
            get
            {
                return this.addFavouriteCommand ?? (this.addFavouriteCommand = new Command(this.AddFavouriteClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when carousel view item is swiped.
        /// </summary> 
        public Command SelectionCommand
        {
            get
            {
                return this.selectionCommand ?? (this.selectionCommand = new Command(this.SelectionClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when ViewAll Command is tapped.
        /// </summary>
        public Command ViewAllCommand
        {
            get
            {
                return this.viewAllCommand ?? (this.viewAllCommand = new Command(this.ViewAllClicked));
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
        /// Invoked when the the travel places item is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void TravelPlacesClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the the top destinations item is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void TopDestinationsClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the the best places item is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void BestPlacesClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the favourite button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddFavouriteClicked(object obj)
        {
            if (obj is Model travel)
            {
                travel.IsFavourite = !travel.IsFavourite;
            }
        }

        /// <summary>
        /// Invoked when carousel view item is swiped.
        /// </summary>
        /// <param name="obj">The rotator item</param>
        private void SelectionClicked(object obj)
        {
            this.SelectedIndex = this.TravelPlaces.IndexOf(obj);
        }

        /// <summary>
        /// Invoked when ViewAll item is clicked.
        /// </summary>
        /// <param name="obj">The rotator item</param>
        private void ViewAllClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}