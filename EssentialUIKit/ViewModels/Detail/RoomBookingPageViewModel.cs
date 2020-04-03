using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using EssentialUIKit.Models;
using EssentialUIKit.Models.ContactUs;
using EssentialUIKit.Models.Detail;
using Syncfusion.SfMaps.XForms;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using SelectionChangedEventArgs = Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for room booking page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class RoomBookingPageViewModel : BaseViewModel
    {
        #region Fields

        private RoomDetail roomDetail;

        private readonly double productRating;

        private ObservableCollection<Review> reviews;

        private List<RoomDetail> facilities;

        private List<RoomDetail> previewImages;

        private bool isReviewVisible;

        private ObservableCollection<MapMarker> customMarkers;

        private List<RoomDetail> guestsCollection;

        private List<RoomDetail> bedsCollection;

        private Point geoCoordinate;

        private bool isDropDownOpen;

        IList<DateTime> selectedDates;

        private string selectionChangedCommand;

        private ObservableCollection<object> calender;

        private int selectedIndex;

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the combo box is clicked for guest.
        /// </summary>
        public Command GuestCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the combo box is clicked for bed.
        /// </summary>
        public Command BedCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the calender is clicked.
        /// </summary>
        public ICommand OnSelectionChanged { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the book button is clicked.
        /// </summary>
        private Command bookCommand;

        /// <summary>
        /// Gets or sets the command is executed when the carousel item is swiped.
        /// </summary>
        private Command selectionCommand;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="RoomBookingPageViewModel" /> class.
        /// </summary>

        public RoomBookingPageViewModel()
        {        
            OnSelectionChanged = new Command<SelectionChangedEventArgs>(SelectionChanged);

            GuestCommand = new Command(this.GuestSelectionChanged);

            BedCommand = new Command(this.BedSelectionChanged);

            this.FavouriteCommand = new Command(this.FavouriteButtonClicked);

            this.Calender = new ObservableCollection<object>() { "i" };

            this.previewImages = new List<RoomDetail>()
            {
                new RoomDetail{ImagePath="HotelImage1.png"},
                new RoomDetail{ImagePath="HotelImage2.jpeg"},
                new RoomDetail{ImagePath="HotelImage3.jpeg"},
                new RoomDetail{ImagePath="HotelImage4.jpeg"},
                new RoomDetail{ImagePath="HotelImage5.jpeg" },
                new RoomDetail{ImagePath="HotelImage6.jpeg"}
            };        

            this.facilities = new List<RoomDetail>()
            {
               new RoomDetail
               {
                   Icon="\ue704",
                   Facility="Wi-Fi"
               },
                new RoomDetail
               {
                   Icon="\ue74e",
                   Facility="Kitchen"
               },
                 new RoomDetail
               {
                   Icon="\ue740",
                   Facility="Parking"
               },
                  new RoomDetail
               {
                   Icon="\ue74c",
                   Facility="Gym"
               }
            };

            this.reviews = new ObservableCollection<Review>
            {
                new Review
                {
                    CustomerImage = "ProfileImage10.png",
                    CustomerName = "Jane Deo",
                    Comment = "Great Resort, excellent hospitality!",
                    ReviewedDate = "29 Dec, 2019",
                    Rating = 5,
                    Images = new List<string>
                    {
                        "HotelImage1.png",
                        "HotelImage4.jpeg",
                        "HotelImage6.jpeg"
                    }
                },
                new Review
                {
                    CustomerImage = "ProfileImage11.png",
                    CustomerName = "Alise Valasquez",
                    Comment = "Best resort on the planet. LOVE our visits there.",
                    ReviewedDate = "29 Dec, 2019",
                    Rating = 5,
                    Images = new List<string>
                    {
                       "HotelImage2.jpeg",
                       "HotelImage3.jpeg",
                       "HotelImage7.jpeg"
                    }
                }
            };

            this.BedsCollection = new List<RoomDetail>()
            {
                new RoomDetail{ DisplayText="1 Bed", ValueText=1 },
                new RoomDetail { DisplayText="2 Beds", ValueText=2 },
                new RoomDetail{ DisplayText="3 Beds", ValueText=3 }
            };

            this.GuestsCollection = new List<RoomDetail>()
            {
                new RoomDetail{ DisplayText="1 Guest", ValueText=1 },
                new RoomDetail { DisplayText="2 Guests", ValueText=2 },
                new RoomDetail{ DisplayText="3 Guests", ValueText=3 }
            };

            this.CustomMarkers = new ObservableCollection<MapMarker>();
            this.GetPinLocation();

            this.RoomDetail = new RoomDetail
            {
                Name = "Modern Resort", 
                OverallRating = 5,
                TotalReviews = "534 Reviews",
                ResortDescription = "A charming oceanfront resort with 38 hotel rooms, studios, and suites, most with a balcony and jacuzzi, located on the turquoise water of the Atlantic Ocean.",              
                Address = "7654 Cleveland Street, Phoenixville, PA 19460",
                PhoneNumber = "+1 202-555-0101",
                Cost = 30,
                TotalDays=1,
                Reviews = reviews
            };

            if (this.RoomDetail.Reviews == null || this.RoomDetail.Reviews.Count == 0)
            {
                this.IsReviewVisible = true;
            }
            else
            {
                foreach (var review in this.RoomDetail.Reviews)
                {
                    this.productRating += review.Rating;
                }
            }

            if (this.productRating > 0)
                this.RoomDetail.OverallRating = this.productRating / this.RoomDetail.Reviews.Count;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that has been bound with icon and labels, which display the resort details.
        /// </summary>
        public RoomDetail RoomDetail
        {
            get
            {
                return this.roomDetail;
            }

            set
            {
                if (this.roomDetail == value)
                {
                    return;
                }

                this.roomDetail = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property IsReviewVisible.
        /// </summary>
        public bool IsReviewVisible
        {
            get
            {
                if (RoomDetail.Reviews.Count == 0)
                {
                    this.isReviewVisible = true;
                }

                return this.isReviewVisible;
            }
            set
            {
                this.isReviewVisible = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the beds collection.
        /// </summary>
        public ObservableCollection<object> Calender
        {
            get
            {
                return this.calender;
            }

            set
            {
                this.calender = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the facilities items collection.
        /// </summary>
        public List<RoomDetail> Facilities
        {
            get
            {
                return this.facilities;
            }

            set
            {
                this.facilities = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the previewImages collection.
        /// </summary>
        public List<RoomDetail> PreviewImages
        {
            get
            {
                return this.previewImages;
            }

            set
            {
                this.previewImages = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the beds collection.
        /// </summary>
        public List<RoomDetail> BedsCollection
        {
            get
            {
                return this.bedsCollection;
            }

            set
            {
                this.bedsCollection = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the guests collection.
        /// </summary>
        public List<RoomDetail> GuestsCollection
        {
            get
            {
                return this.guestsCollection;
            }

            set
            {
                this.guestsCollection = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the CustomMarkers collection.
        /// </summary>
        public ObservableCollection<MapMarker> CustomMarkers
        {
            get
            {
                return this.customMarkers;
            }

            set
            {
                this.customMarkers = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the geo coordinate.
        /// </summary>
        public Point GeoCoordinate
        {
            get
            {
                return this.geoCoordinate;
            }

            set
            {
                this.geoCoordinate = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the IsDropDownOpen.
        /// </summary>
        public bool IsDropDownOpen
        {
            get
            {
                return this.isDropDownOpen;
            }

            set
            {
                this.isDropDownOpen = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the carusel view swipe item index.
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex;}
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

        /// <summary>
        /// Gets or sets the SelectionChangedCommand.
        /// </summary>
        public string SelectionChangedCommand
        {
            get { return selectionChangedCommand; }
            set { selectionChangedCommand = value; }
        }

        // <summary>
        /// Gets or sets the command that will be executed when an book button is selected.
        /// </summary>   
        public Command BookCommand
        {
            get
            {
                return this.bookCommand ?? (this.bookCommand = new Command(this.BookClicked));
            }
        }

        // <summary>
        /// Gets or sets the command that will be executed when an book button is selected.
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
        private void GetPinLocation()
        {
            this.CustomMarkers.Add(
                new LocationMarker
                {
                    PinImage = "Pin.png",
                    Latitude = "40.133808",
                    Longitude = "-75.516279"
                });

            foreach (var marker in this.CustomMarkers)
            {
                this.GeoCoordinate = new Point(Convert.ToDouble(marker.Latitude, CultureInfo.CurrentCulture), Convert.ToDouble(marker.Longitude, CultureInfo.CurrentCulture));
            }         
        }

        private void SelectionChanged( SelectionChangedEventArgs e)
        {
            selectedDates = e.DateAdded;
            this.RoomDetail.SelectedRanges = (selectedDates[0].Date.ToString("MMM dd")) + " - " + (selectedDates[selectedDates.Count - 1].Date.ToString("MMM dd"));
            IsDropDownOpen = false;
        }

        private void GuestSelectionChanged(object obj)
        {
            //Do your command action
        }

        private void BedSelectionChanged(object obj)
        {
            //Do your command action
        }

        private void FavouriteButtonClicked(object obj)
        {
            var button = obj as SfButton;

            if (button == null)
            {
                return;
            }

            if (button.Text == "\ue701")
            {
                button.Text = "\ue732";
                Application.Current.Resources.TryGetValue("PrimaryColor", out var retVal);
                button.TextColor = (Color)retVal;
            }
            else
            {
                button.Text = "\ue701";
                Application.Current.Resources.TryGetValue("Gray-600", out var retVal);
                button.TextColor = (Color)retVal;
            }
        }

        /// <summary>
        /// Invoked when the book button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void BookClicked(object obj)
        {
            //Do something
        }

        /// <summary>
        /// Invoked when carousel view item is swiped.
        /// </summary>
        /// <param name="obj">The rotator item</param>
        private void SelectionClicked(object obj)
        {
            this.SelectedIndex = this.PreviewImages.IndexOf(obj);
        }

        #endregion
    }

}
