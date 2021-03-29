using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using EssentialUIKit.Models;
using EssentialUIKit.Models.Detail;
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

        private readonly double productRating;

        private RoomDetail roomDetail;

        private ObservableCollection<Review> reviews;

        private List<RoomDetail> facilities;

        private List<RoomDetail> previewImages;

        private bool isReviewVisible;

        private bool isFavourite;

        private string mapMarkerLatitude;

        private string mapMarkerLongitude;

        private string mapMarkerImage;

        private List<RoomDetail> guestsCollection;

        private List<RoomDetail> bedsCollection;

        private Point geoCoordinate;

        private bool isDropDownOpen;

        private IList<DateTime> selectedDates;

        private string selectionChangedCommand;

        private ObservableCollection<object> calender;

        private int selectedIndex;

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the book button is clicked.
        /// </summary>
        private Command bookCommand;

        /// <summary>
        /// Gets or sets the command is executed when the  selection button is clicked.
        /// </summary>
        private Command selectionCommand;

        /// <summary>
        /// Gets or sets the command is executed when the more button is clicked.
        /// </summary>
        private Command moreCommand;

        /// <summary>
        /// Gets or sets the command is executed when the  showAll button is clicked.
        /// </summary>
        private Command showAllCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="RoomBookingPageViewModel" /> class.
        /// </summary>
        public RoomBookingPageViewModel()
        {
            this.OnSelectionChanged = new Command<SelectionChangedEventArgs>(this.SelectionChanged);

            this.GuestCommand = new Command(this.GuestSelectionChanged);

            this.BedCommand = new Command(this.BedSelectionChanged);

            this.FavouriteCommand = new Command(this.FavouriteButtonClicked);

            this.Calender = new ObservableCollection<object>() { "i" };

            this.previewImages = new List<RoomDetail>()
            {
                new RoomDetail{ImagePath = "HotelImage1.png"},
                new RoomDetail{ImagePath = "HotelImage2.jpeg"},
                new RoomDetail{ImagePath = "HotelImage3.jpeg"},
                new RoomDetail{ImagePath = "HotelImage4.jpeg"},
                new RoomDetail{ImagePath = "HotelImage5.jpeg" },
                new RoomDetail{ImagePath = "HotelImage6.jpeg"},
            };

            this.facilities = new List<RoomDetail>()
            {
               new RoomDetail
               {
                   Icon = "\ue704",
                   Facility = "Wi-Fi",
               },
               new RoomDetail
               {
                   Icon = "\ue74e",
                   Facility = "Kitchen",
               },
               new RoomDetail
               {
                   Icon = "\ue740",
                   Facility = "Parking",
               },
               new RoomDetail
               {
                   Icon = "\ue74c",
                   Facility = "Gym",
               },
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
                    CustomerReviewImages = new List<string>
                    {
                        "HotelImage1.png",
                        "HotelImage4.jpeg",
                        "HotelImage6.jpeg",
                    },
                },
                new Review
                {
                    CustomerImage = "ProfileImage11.png",
                    CustomerName = "Alise Valasquez",
                    Comment = "Best resort on the planet. LOVE our visits there.",
                    ReviewedDate = "29 Dec, 2019",
                    Rating = 5,
                    CustomerReviewImages = new List<string>
                    {
                       "HotelImage2.jpeg",
                       "HotelImage3.jpeg",
                       "HotelImage7.jpeg",
                    },
                },
            };

            this.BedsCollection = new List<RoomDetail>()
            {
                new RoomDetail{ DisplayText = "1 Bed", ValueText = 1 },
                new RoomDetail { DisplayText = "2 Beds", ValueText = 2 },
                new RoomDetail{ DisplayText = "3 Beds", ValueText = 3 },
            };

            this.GuestsCollection = new List<RoomDetail>()
            {
                new RoomDetail{ DisplayText = "1 Guest", ValueText = 1 },
                new RoomDetail { DisplayText = "2 Guests", ValueText = 2 },
                new RoomDetail{ DisplayText = "3 Guests", ValueText = 3 },
            };
            this.MapMarkerImage = "Pin.png";
            this.MapMarkerLatitude = "40.133808";
            this.MapMarkerLongitude = "-75.516279";
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
                TotalDays = 1,
                Reviews = reviews,
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
            {
                this.RoomDetail.OverallRating = this.productRating / this.RoomDetail.Reviews.Count;
            }
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

                this.SetProperty(ref this.roomDetail, value);
            }
        }

        /// <summary>
        /// Gets or sets the property IsReviewVisible.
        /// </summary>
        public bool IsReviewVisible
        {
            get
            {
                if (this.RoomDetail.Reviews.Count == 0)
                {
                    this.isReviewVisible = true;
                }

                return this.isReviewVisible;
            }

            set
            {
                this.SetProperty(ref this.isReviewVisible, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the room is favourite or not.
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
        /// Gets or sets a value of map marker latitude.
        /// </summary>
        public string MapMarkerLatitude
        {
            get
            {
                return this.mapMarkerLatitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLatitude, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker longitude.
        /// </summary>
        public string MapMarkerLongitude
        {
            get
            {
                return this.mapMarkerLongitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLongitude, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for map marker template image.
        /// </summary>
        public string MapMarkerImage
        {
            get
            {
                return this.mapMarkerImage;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerImage, value);
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

            private set
            {
                this.SetProperty(ref this.calender, value);
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

            private set
            {
                this.SetProperty(ref this.facilities, value);
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

            private set
            {
                this.SetProperty(ref this.previewImages, value);
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

            private set
            {
                this.SetProperty(ref this.bedsCollection, value);
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

            private set
            {
                this.SetProperty(ref this.guestsCollection, value);
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
                this.SetProperty(ref this.geoCoordinate, value);
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
                this.SetProperty(ref this.isDropDownOpen, value);
            }
        }

        /// <summary>
        /// Gets or sets the carusel view swipe item index.
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

        /// <summary>
        /// Gets or sets the SelectionChangedCommand.
        /// </summary>
        public string SelectionChangedCommand
        {
            get { return this.selectionChangedCommand; }
            set { this.selectionChangedCommand = value; }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when an book button is selected.
        /// </summary>
        public Command BookCommand
        {
            get
            {
                return this.bookCommand ?? (this.bookCommand = new Command(this.BookClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when an book button is selected.
        /// </summary>
        public Command SelectionCommand
        {
            get
            {
                return this.selectionCommand ?? (this.selectionCommand = new Command(this.SelectionClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when an more button is selected.
        /// </summary>
        public Command MoreCommand
        {
            get
            {
                return this.moreCommand ?? (this.moreCommand = new Command(this.MoreClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when an more button is selected.
        /// </summary>
        public Command ShowAllCommand
        {
            get
            {
                return this.showAllCommand ?? (this.showAllCommand = new Command(this.ShowAllClicked));
            }
        }

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

        #endregion

        #region Methods
        private void GetPinLocation()
        {
            this.GeoCoordinate = new Point(Convert.ToDouble(this.MapMarkerLatitude, CultureInfo.CurrentCulture), Convert.ToDouble(this.MapMarkerLongitude, CultureInfo.CurrentCulture));
        }

        private void SelectionChanged(SelectionChangedEventArgs e)
        {
            this.selectedDates = e.DateAdded;
            if (this.selectedDates.Count != 0)
            {
                this.RoomDetail.SelectedRanges = this.selectedDates[0].Date.ToString("MMM dd", CultureInfo.CurrentCulture) + " - " + this.selectedDates[this.selectedDates.Count - 1].Date.ToString("MMM dd", CultureInfo.CurrentCulture);
                this.IsDropDownOpen = false;
            }
        }

        private void GuestSelectionChanged(object obj)
        {
            // Do your command action
        }

        private void BedSelectionChanged(object obj)
        {
            // Do your command action
        }

        private void FavouriteButtonClicked(object obj)
        {
            if (obj != null && (obj is RoomBookingPageViewModel))
            {
                (obj as RoomBookingPageViewModel).IsFavourite = (obj as RoomBookingPageViewModel).IsFavourite ? false : true;
            }
        }

        /// <summary>
        /// Invoked when the book button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void BookClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when carousel view item is swiped.
        /// </summary>
        /// <param name="obj">The rotator item</param>
        private void SelectionClicked(object obj)
        {
            this.SelectedIndex = this.PreviewImages.IndexOf(obj);
        }

        /// <summary>
        /// Invoked when the more button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MoreClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the show all button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ShowAllClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
