using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Model = EssentialUIKit.Models.Catalog.Travel;

namespace EssentialUIKit.ViewModels.Catalog
{
    /// <summary>
    /// ViewModel for navigation travel page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class NavigationTravelPageViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Model> travelPlaces;

        private ObservableCollection<Model> topDestinations;

        private ObservableCollection<Model> bestPlaces;

        private Command addFavouriteCommand;

        private Command selectionCommand;

        private int selectedIndex;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NavigationTravelPageViewModel" /> class.
        /// </summary>
        public NavigationTravelPageViewModel()
        {
            this.TravelPlaces = new ObservableCollection<Model>
            {
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Surf-hotel-in-dubai.jpeg",
                    Place = "Dubai",
                    Details = "A melting pot of cultures, Dubai is the most advanced city in the Arab world. Lined with luxury resorts, there are activities for every interest, from camel racing to fossil cliffs to extravagant shopping opportunities."
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Mount-fuji.jpeg",
                    Place = "Mount Fuji",
                    Details = "Japan’s most famous, holy mountain dominates the landscape of three prefectures—when you can see it. Fuji-san is shy and often obscured by clouds, but take the slow train through Shizuoka, or go shopping at the grand Gotemba outlet mall and you might get lucky."
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "London.jpeg",
                    Place = "London",
                    Details = "The bustling capital of the United Kingdom has enough historical landmarks, architectural beauties, and free museums to keep even the pickiest traveler occupied for days, if not weeks."
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Singapore.jpeg",
                    Place = "Singapore",
                    Details = "At only 725 sq. km., Singapore is one of the smallest countries in the world, but it packs a major punch in terms of reasons to visit."
                }
            };

            this.TopDestinations = new ObservableCollection<Model>
            {
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Venice.jpeg",
                    Place = "Venice, Italy",
                    Details = "Venice is arguably the most beautiful city in the world. The world seems to agree, sending 30 million tourists to walk its cobblestone streets, cross its ornate bridges, and sail down its elegant canals every year."
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Santorini-greece.jpeg",
                    Place = "Santorini, Greece",
                    Details = "The result of volcanic eruptions that devastated ancient civilizations, Santorini, locally known as Thira, is now a tourism must-do. The white buildings and blue roofs of Oia town are an icon of Greece itself."
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Salt-Pond-Bay-Thailand.jpeg",
                    Place = "Maya Beach, Thailand",
                    Details = "The crystal blue waters of this cove were made famous by the 2000 movie The Beach. Surrounded by dramatic cliffs and a white-sand beach, Maya Beach is a popular day trip."
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Gran-via-Valencia.jpeg",
                    Place = "Madrid, Spain",
                    Details = "The capital of Spain tends to be overlooked in favor of the colorful Barcelona, but this city has a glamor of its own."
                },
            };

            this.BestPlaces = new ObservableCollection<Model>
            {
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Salt-Pond-Bay-Thailand.jpeg",
                    Place = "Maya Bay, Thailand"
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Gran-via-Valencia.jpeg",
                    Place = "Madrid, Spain"
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Venice.jpeg",
                    Place = "Venice, Italy"
                },
                new Model
                {
                    ImagePath = App.BaseImageUrl + "Santorini-greece.jpeg",
                    Place = "Santorini, Greece"
                },
            };

            this.TravelPlacesCommand = new Command(this.TravelPlacesClicked);
            this.TopDestinationsCommand = new Command(this.TopDestinationsClicked);
            this.BestPlacesCommand = new Command(this.BestPlacesClicked);
            this.ItemSelectedCommand = new Command(this.ItemSelected);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the property that has been bound with the rotator view, which displays the travel places and details.
        /// </summary>
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

                this.travelPlaces = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property which displays top destinations, details and price.
        /// </summary>
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

                this.topDestinations = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property which displays the names and images of best places.
        /// </summary>
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

                this.bestPlaces = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected index of the rotator.
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex == value)
                {
                    return;
                }
                selectedIndex = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will executed when the travel places item is clicked.
        /// </summary>
        public Command TravelPlacesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will executed when the top destinations item is clicked.
        /// </summary>
        public Command TopDestinationsCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will executed when the best places item is clicked.
        /// </summary>
        public Command BestPlacesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

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

        // <summary>
        /// Gets or sets the command that will be executed when carousel view item is swiped.
        /// </summary>   
        public Command SelectionCommand
        {
            get
            {
                return this.selectionCommand ?? (this.selectionCommand = new Command(this.SelectionClicked));
            }
        }

        #endregion

        #region Methods

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
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ItemSelected(object obj)
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
                travel.IsFavourite = !travel.IsFavourite;
        }

        /// <summary>
        /// Invoked when carousel view item is swiped.
        /// </summary>
        /// <param name="obj">The rotator item</param>
        private void SelectionClicked(object obj)
        {
            this.SelectedIndex = this.TravelPlaces.IndexOf(obj);
        }
        #endregion
    }
}