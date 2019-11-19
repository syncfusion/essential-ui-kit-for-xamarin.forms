using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using ProfileModel = EssentialUIKit.Models.Profile;

namespace EssentialUIKit.ViewModels.Social
{
    /// <summary>
    /// ViewModel for social profile pages.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SocialProfileViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<ProfileModel> interests;

        private ObservableCollection<ProfileModel> connnections;

        private ObservableCollection<string> pictures;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SocialProfileViewModel" /> class.
        /// </summary>
        public SocialProfileViewModel()
        {
            this.HeaderImagePath = App.BaseImageUrl + "Album2.png";
            this.ProfileImage = App.BaseImageUrl + "ProfileImage16.png";
            this.ProfileName = "Lela Cortez";
            this.Designation = "Designer";
            this.State = "San Francisco";
            this.Country = "CA";
            this.About = "I’m a UMN graduate (go Gophers!) and Minnesota native, but I’m already loving my new home in the Golden Gate City! I can’t wait to explore more of the great music scene here.";
            this.PostsCount = 8;
            this.FollowersCount = 45;
            this.FollowingCount = 45;

            this.Interests = new ObservableCollection<ProfileModel>()
            {
                 new ProfileModel { Name = "Food", ImagePath = App.BaseImageUrl + "Recipe12.png" },
                 new ProfileModel { Name = "Travel", ImagePath = App.BaseImageUrl + "Album5.png" },
                 new ProfileModel { Name = "Music", ImagePath = App.BaseImageUrl + "ArticleImage7.jpg" },
                 new ProfileModel { Name = "Bags", ImagePath = App.BaseImageUrl + "Accessories.png" },
                 new ProfileModel { Name = "Market", ImagePath = App.BaseImageUrl + "PersonalCare.png" },
                 new ProfileModel { Name = "Food", ImagePath = App.BaseImageUrl + "Recipe12.png" },
                 new ProfileModel { Name = "Travel", ImagePath = App.BaseImageUrl + "Album5.png" },
                 new ProfileModel { Name = "Music", ImagePath = App.BaseImageUrl + "ArticleImage7.jpg" },
                 new ProfileModel { Name = "Bags", ImagePath = App.BaseImageUrl + "Accessories.png" },
                 new ProfileModel { Name = "Market", ImagePath = App.BaseImageUrl + "PersonalCare.png" },
            };

            this.Connections = new ObservableCollection<ProfileModel>()
            {
                 new ProfileModel { Name = "Rose King", ImagePath = App.BaseImageUrl + "ProfileImage7.png" },
                 new ProfileModel { Name = "Jeanette Bell", ImagePath = App.BaseImageUrl + "ProfileImage9.png" },
                 new ProfileModel { Name = "Lily Castro", ImagePath = App.BaseImageUrl + "ProfileImage10.png" },
                 new ProfileModel { Name = "Susie Moss", ImagePath = App.BaseImageUrl + "ProfileImage11.png" },
                 new ProfileModel { Name = "Rose King", ImagePath = App.BaseImageUrl + "ProfileImage7.png" },
                 new ProfileModel { Name = "Jeanette Bell", ImagePath = App.BaseImageUrl + "ProfileImage9.png" },
                 new ProfileModel { Name = "Lily Castro", ImagePath = App.BaseImageUrl + "ProfileImage10.png" },
                 new ProfileModel { Name = "Susie Moss", ImagePath = App.BaseImageUrl + "ProfileImage11.png" },
            };

            this.Pictures = new ObservableCollection<string>()
            {
                 App.BaseImageUrl + "ProfileImage8.png",
                 App.BaseImageUrl + "Album6.png",
                 App.BaseImageUrl + "ArticleImage4.jpg",
                 App.BaseImageUrl + "Recipe17.png",
                 App.BaseImageUrl + "ArticleImage5.jpg",
                 App.BaseImageUrl + "Mask.png",
            };

            this.FollowCommand = new Command(this.FollowClicked);
            this.AddConnectionCommand = new Command(this.AddConnectionClicked);
            this.ImageTapCommand = new Command(this.ImageClicked);
            this.ProfileSelectedCommand = new Command(this.ProfileClicked);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that is executed when the Follow button is clicked.
        /// </summary>
        public ICommand FollowCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the AddConnection button is clicked.
        /// </summary>
        public ICommand AddConnectionCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Image is tapped.
        /// </summary>
        public ICommand ImageTapCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the profile item is tapped.
        /// </summary>
        public ICommand ProfileSelectedCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the interests collection.
        /// </summary>
        public ObservableCollection<ProfileModel> Interests
        {
            get
            {
                return this.interests;
            }

            set
            {
                this.interests = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the connections collection.
        /// </summary>
        public ObservableCollection<ProfileModel> Connections
        {
            get
            {
                return this.connnections;
            }

            set
            {
                this.connnections = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the photos collection.
        /// </summary>
        public ObservableCollection<string> Pictures
        {
            get
            {
                return this.pictures;
            }

            set
            {
                this.pictures = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the header image path.
        /// </summary>
        public string HeaderImagePath { get; set; }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the profile name
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the designation
        /// </summary>
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the about
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Gets or sets the posts count
        /// </summary>
        public int PostsCount { get; set; }

        /// <summary>
        /// Gets or sets the followers count
        /// </summary>
        public int FollowersCount { get; set; }

        /// <summary>
        /// Gets or sets the followings count
        /// </summary>
        public int FollowingCount { get; set; }

        #endregion
        
        #region Methods

        /// <summary>
        /// Invoked when the Follow button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FollowClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the AddConnection button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddConnectionClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Image is tapped.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ImageClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the profile is tapped.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ProfileClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
