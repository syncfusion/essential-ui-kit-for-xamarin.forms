using EssentialUIKit.Models.Social;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Profile = EssentialUIKit.Models.Social.Profile;

namespace EssentialUIKit.ViewModels.Social
{
    /// <summary>
    /// ViewModel for social profile pages.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SocialProfileViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Profile> interests;

        private ObservableCollection<Profile> connnections;

        private ObservableCollection<string> pictures;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SocialProfileViewModel" /> class.
        /// </summary>
        public SocialProfileViewModel()
        {
            HeaderImagePath = App.BaseImageUrl + "Album2.png";
            ProfileImage = App.BaseImageUrl + "ProfileImage16.png";
            ProfileName = "Lela Cortez";
            Designation = "Designer";
            State = "San Francisco";
            Country = "CA";
            About = "I’m a UMN graduate (go Gophers!) and Minnesota native, but I’m already loving my new home in the Golden Gate City! I can’t wait to explore more of the great music scene here.";
            PostsCount = 8;
            FollowersCount = 45;
            FollowingCount = 45;

            Interests = new ObservableCollection<Profile>();
            Interests.Add(new Profile { Name = "Food", ImagePath = App.BaseImageUrl + "Recipe12.png" });
            Interests.Add(new Profile { Name = "Travel", ImagePath = App.BaseImageUrl + "Album5.png" });
            Interests.Add(new Profile { Name = "Music", ImagePath = App.BaseImageUrl + "ArticleImage7.jpg" });
            Interests.Add(new Profile { Name = "Bags", ImagePath = App.BaseImageUrl +  "Accessories.png" });
            Interests.Add(new Profile { Name = "Market", ImagePath = App.BaseImageUrl + "PersonalCare.png" });
            Interests.Add(new Profile { Name = "Food", ImagePath = App.BaseImageUrl + "Recipe12.png" });
            Interests.Add(new Profile { Name = "Travel", ImagePath = App.BaseImageUrl + "Album5.png" });
            Interests.Add(new Profile { Name = "Music", ImagePath = App.BaseImageUrl + "ArticleImage7.jpg" });
            Interests.Add(new Profile { Name = "Bags", ImagePath = App.BaseImageUrl + "Accessories.png" });
            Interests.Add(new Profile { Name = "Market", ImagePath = App.BaseImageUrl + "PersonalCare.png" });

            Connections = new ObservableCollection<Profile>();            
            Connections.Add(new Profile { Name = "Rose King", ImagePath = App.BaseImageUrl + "ProfileImage7.png" });
            Connections.Add(new Profile { Name = "Jeanette Bell", ImagePath = App.BaseImageUrl + "ProfileImage9.png" });
            Connections.Add(new Profile { Name = "Lily Castro", ImagePath = App.BaseImageUrl + "ProfileImage10.png" });
            Connections.Add(new Profile { Name = "Susie Moss", ImagePath = App.BaseImageUrl + "ProfileImage11.png" });
            Connections.Add(new Profile { Name = "Rose King", ImagePath = App.BaseImageUrl + "ProfileImage7.png" });
            Connections.Add(new Profile { Name = "Jeanette Bell", ImagePath = App.BaseImageUrl + "ProfileImage9.png" });
            Connections.Add(new Profile { Name = "Lily Castro", ImagePath = App.BaseImageUrl + "ProfileImage10.png" });
            Connections.Add(new Profile { Name = "Susie Moss", ImagePath = App.BaseImageUrl + "ProfileImage11.png" });            

            Pictures = new ObservableCollection<string>();
            Pictures.Add(App.BaseImageUrl + "ProfileImage8.png");
            Pictures.Add(App.BaseImageUrl + "Album6.png");
            Pictures.Add(App.BaseImageUrl + "ArticleImage4.jpg");
            Pictures.Add(App.BaseImageUrl + "Recipe17.png");
            Pictures.Add(App.BaseImageUrl + "ArticleImage5.jpg");
            Pictures.Add(App.BaseImageUrl + "Mask.png");          

            this.FollowCommand = new Command(FollowClicked);
            this.AddConnectionCommand = new Command(AddConnectionClicked);
            this.ImageTapCommand = new Command(ImageClicked);
            this.ProfileSelectedCommand = new Command(ProfileClicked);
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

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the interests collection.
        /// </summary>
        public ObservableCollection<Profile> Interests
        {
            get { return interests; }
            set { interests = value; OnPropertyChanged(); }
        }        

        /// <summary>
        /// Gets or sets the connections collection.
        /// </summary>
        public ObservableCollection<Profile> Connections
        {
            get { return connnections; }
            set { connnections = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the photos collection.
        /// </summary>
        public ObservableCollection<string> Pictures
        {
            get { return pictures; }
            set { pictures = value; OnPropertyChanged(); }
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
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Invoked when the Follow button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FollowClicked(object obj)
        {
            //Do something
        }

        /// <summary>
        /// Invoked when the AddConnection button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddConnectionClicked(object obj)
        {
            //Do something
        }

        /// <summary>
        /// Invoked when the Image is tapped.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ImageClicked(object obj)
        {
            //Do something
        }

        /// <summary>
        /// Invoked when the profile is tapped.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ProfileClicked(object obj)
        {
            //Do something
        }

        #endregion
    }
}
