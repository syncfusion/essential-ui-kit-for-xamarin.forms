using Syncfusion.XForms.Buttons;
using System.Collections.ObjectModel;
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

        private ObservableCollection<ProfileModel> pictures;

        private string headerImagePath;

        private string profileImage;

        private string backgroundImage;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SocialProfileViewModel" /> class.
        /// </summary>
        public SocialProfileViewModel()
        {
            this.HeaderImagePath = "Album2.png";
            this.ProfileImage = "ProfileImage16.png";
            this.BackgroundImage = "Sky-Image.png";
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
                new ProfileModel { Name = "Food", ImagePath = "Recipe12.png" },
                new ProfileModel { Name = "Travel", ImagePath = "Album5.png" },
                new ProfileModel { Name = "Music", ImagePath = "ArticleImage7.jpg" },
                new ProfileModel { Name = "Bags", ImagePath = "Accessories.png" },
                new ProfileModel { Name = "Market", ImagePath = "PersonalCare.png" },
                new ProfileModel { Name = "Food", ImagePath = "Recipe12.png" },
                new ProfileModel { Name = "Travel", ImagePath = "Album5.png" },
                new ProfileModel { Name = "Music", ImagePath = "ArticleImage7.jpg" },
                new ProfileModel { Name = "Bags", ImagePath = "Accessories.png" },
                new ProfileModel { Name = "Market", ImagePath = "PersonalCare.png" }
            };

            this.Connections = new ObservableCollection<ProfileModel>()
            {
                new ProfileModel { Name = "Rose King", ImagePath = "ProfileImage7.png" },
                new ProfileModel { Name = "Jeanette Bell", ImagePath = "ProfileImage9.png" },
                new ProfileModel { Name = "Lily Castro", ImagePath = "ProfileImage10.png" },
                new ProfileModel { Name = "Susie Moss", ImagePath = "ProfileImage11.png" },
                new ProfileModel { Name = "Rose King", ImagePath = "ProfileImage7.png" },
                new ProfileModel { Name = "Jeanette Bell", ImagePath = "ProfileImage9.png" },
                new ProfileModel { Name = "Lily Castro", ImagePath = "ProfileImage10.png" },
                new ProfileModel { Name = "Susie Moss", ImagePath = "ProfileImage11.png" }
            };

            this.Pictures = new ObservableCollection<ProfileModel>()
            {
                new ProfileModel { ImagePath = "ProfileImage8.png" },
                new ProfileModel { ImagePath = "Album6.png" },
                new ProfileModel { ImagePath = "ArticleImage4.jpg" },
                new ProfileModel { ImagePath = "Recipe17.png" },
                new ProfileModel { ImagePath = "ArticleImage5.jpg" },
                new ProfileModel { ImagePath = "Mask.png" }
            };

            this.FollowCommand = new Command(this.FollowClicked);
            this.MessageCommand = new Command(this.MessageClicked);
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
        /// Gets or sets the command that is executed when the message button is clicked.
        /// </summary>
        public ICommand MessageCommand { get; set; }

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
        public ObservableCollection<ProfileModel> Pictures
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
        public string HeaderImagePath
        {
            get { return App.BaseImageUrl + this.headerImagePath; }
            set { this.headerImagePath = value; }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage
        {
            get { return App.BaseImageUrl + this.profileImage; }
            set { this.profileImage = value; }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        public string BackgroundImage
        {
            get { return App.BaseImageUrl + this.backgroundImage; }
            set { this.backgroundImage = value; }
        }

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
            SfButton button = obj as SfButton;
            if (button.Text == "FOLLOW")
            {
                button.Text = "FOLLOWED";
            }
            else if (button.Text == "FOLLOWED")
            {
                button.Text = "FOLLOW";
            } 
        }

        /// <summary>
        /// Invoked when the message button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MessageClicked(object obj)
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
