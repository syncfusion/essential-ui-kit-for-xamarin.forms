using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using ProfileModel = EssentialUIKit.Models.UserProfile;

namespace EssentialUIKit.ViewModels.Social
{
    /// <summary>
    /// ViewModel for social profile pages.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SocialProfileViewModel : BaseViewModel
    {
        #region Fields

        private static SocialProfileViewModel socialProfileViewModel;

        private ObservableCollection<ProfileModel> interests;

        private ObservableCollection<ProfileModel> connnections;

        private ObservableCollection<ProfileModel> pictures;

        private string headerImagePath;

        private string profileImage;

        private string backgroundImage;

        private Command messageCommand;

        private Command addConnectionCommand;

        private Command imageTapCommand;

        private Command profileSelectedCommand;

        private Command settingsCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="SocialProfileViewModel" /> class.
        /// </summary>
        public SocialProfileViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of social profile view model.
        /// </summary>
        public static SocialProfileViewModel BindingContext =>
            socialProfileViewModel = PopulateData<SocialProfileViewModel>("social.json");

        /// <summary>
        /// Gets or sets the interests collection.
        /// </summary>
        [DataMember(Name = "interests")]
        public ObservableCollection<ProfileModel> Interests
        {
            get
            {
                return this.interests;
            }

            set
            {
                this.SetProperty(ref this.interests, value);
            }
        }

        /// <summary>
        /// Gets or sets the connections collection.
        /// </summary>
        [DataMember(Name = "connections")]
        public ObservableCollection<ProfileModel> Connections
        {
            get
            {
                return this.connnections;
            }

            set
            {
                this.SetProperty(ref this.connnections, value);
            }
        }

        /// <summary>
        /// Gets or sets the photos collection.
        /// </summary>
        [DataMember(Name = "pictures")]
        public ObservableCollection<ProfileModel> Pictures
        {
            get
            {
                return this.pictures;
            }

            set
            {
                this.SetProperty(ref this.pictures, value);
            }
        }

        /// <summary>
        /// Gets or sets the header image path.
        /// </summary>
        [DataMember(Name = "headerImagePath")]
        public string HeaderImagePath
        {
            get { return App.ImageServerPath + this.headerImagePath; }
            set { this.headerImagePath = value; }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        [DataMember(Name = "profileImage")]
        public string ProfileImage
        {
            get { return App.ImageServerPath + this.profileImage; }
            set { this.profileImage = value; }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        [DataMember(Name = "backgroundImage")]
        public string BackgroundImage
        {
            get { return App.ImageServerPath + this.backgroundImage; }
            set { this.backgroundImage = value; }
        }

        /// <summary>
        /// Gets or sets the profile name
        /// </summary>
        [DataMember(Name = "profileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the designation
        /// </summary>
        [DataMember(Name = "designation")]
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the about
        /// </summary>
        [DataMember(Name = "about")]
        public string About { get; set; }

        /// <summary>
        /// Gets or sets the posts count
        /// </summary>
        [DataMember(Name = "postsCount")]
        public int PostsCount { get; set; }

        /// <summary>
        /// Gets or sets the followers count
        /// </summary>
        [DataMember(Name = "followersCount")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// Gets or sets the followings count
        /// </summary>
        [DataMember(Name = "followingCount")]
        public int FollowingCount { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that is executed when the message button is clicked.
        /// </summary>
        public ICommand MessageCommand
        {
            get
            {
                return this.messageCommand ?? (this.messageCommand = new Command(this.MessageClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the AddConnection button is clicked.
        /// </summary>
        public ICommand AddConnectionCommand
        {
            get
            {
                return this.addConnectionCommand ?? (this.addConnectionCommand = new Command(this.AddConnectionClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the Image is tapped.
        /// </summary>
        public ICommand ImageTapCommand
        {
            get
            {
                return this.imageTapCommand ?? (this.imageTapCommand = new Command(this.ImageClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the profile item is tapped.
        /// </summary>
        public ICommand ProfileSelectedCommand
        {
            get
            {
                return this.profileSelectedCommand ?? (this.profileSelectedCommand = new Command(this.ProfileClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the setting button is tapped.
        /// </summary>
        public ICommand SettingsCommand
        {
            get
            {
                return this.settingsCommand ?? (this.settingsCommand = new Command(this.SettingButtonClicked));
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

        /// <summary>
        /// Invoked when the setting button is tapped.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SettingButtonClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
