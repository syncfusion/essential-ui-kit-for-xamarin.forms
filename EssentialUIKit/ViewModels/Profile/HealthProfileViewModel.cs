using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using EssentialUIKit.Models;
using Xamarin.Forms;

namespace EssentialUIKit.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for health profile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class HealthProfileViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// To store the health profile data collection.
        /// </summary>
        private ObservableCollection<HealthProfile> cardItems;

        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="HealthProfileViewModel" /> class.
        /// </summary>
        public HealthProfileViewModel()
        {
            cardItems = new ObservableCollection<HealthProfile>()
            {
                new HealthProfile()
                {
                    Category = "Calories Eaten",
                    CategoryValue = "13,100",
                    CategoryImage = "CaloriesEaten.svg"
                },
                new HealthProfile()
                {
                    Category = "Heart Rate",
                    CategoryValue = "87 BPM",
                    CategoryImage = "HeartRate.svg"
                },
                new HealthProfile()
                {
                    Category = "Water Consumed",
                    CategoryValue = "38.6 L",
                    CategoryImage = "WaterConsumed.svg"
                },
                new HealthProfile()
                {
                    Category = "Sleep Duration",
                    CategoryValue = "7.3 H",
                    CategoryImage = "SleepDuration.svg"
                }
            };

            this.ProfileImage = App.BaseImageUrl + "ProfileImage16.png";
            this.ProfileName = "Lela Cortez";
            this.State = "San Francisco";
            this.Country = "CA";
            this.Age = "35";
            this.Weight = "159 Ibs";
            this.Height = "165 cm";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the health profile items collection.
        /// </summary>
        public ObservableCollection<HealthProfile> CardItems
        {
            get
            {
                return this.cardItems;
            }

            set
            {
                this.cardItems = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public string Height { get; set; }

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

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the health profile page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion

        #endregion
    }
}