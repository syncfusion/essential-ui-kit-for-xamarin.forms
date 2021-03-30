using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for burger menu expand page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class MasterPageViewModel : BaseViewModel
    {
        #region Fields

        private static MasterPageViewModel masterPageViewModel;

        private string profileName;

        private string profileImage;

        private string email;

        private Command homeCommand;

        private Command interestsCommand;

        private Command bookmarkCommand;

        private Command activityCommand;

        private Command profileCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MasterPageViewModel" /> class.
        /// </summary>
        public MasterPageViewModel()
        {
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the value of master page view model.
        /// </summary>
        public static MasterPageViewModel BindingContext =>
            masterPageViewModel = PopulateData<MasterPageViewModel>("profile.json");

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        [DataMember(Name = "name")]
        public string ProfileName
        {
            get
            {
                return this.profileName;
            }

            set
            {
                if (this.profileName != value)
                {
                    this.SetProperty(ref this.profileName, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        [DataMember(Name = "itemImage")]
        public string ProfileImage
        {
            get
            {
                return App.ImageServerPath + this.profileImage;
            }

            set
            {
                if (this.profileImage != value)
                {
                    this.SetProperty(ref this.profileImage, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email != value)
                {
                    this.SetProperty(ref this.email, value);
                }
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command that is executed when the home view is clicked.
        /// </summary>
        public Command HomeCommand
        {
            get
            {
                return this.homeCommand ?? (this.homeCommand = new Command(this.HomeButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the interests view is clicked.
        /// </summary>
        public Command InterestsCommand
        {
            get
            {
                return this.interestsCommand ?? (this.interestsCommand = new Command(this.InterestsButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the bookmark view is clicked.
        /// </summary>
        public Command BookmarkCommand
        {
            get
            {
                return this.bookmarkCommand ?? (this.bookmarkCommand = new Command(this.BookmarkButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the activity view is clicked.
        /// </summary>
        public Command ActivityCommand
        {
            get
            {
                return this.activityCommand ?? (this.activityCommand = new Command(this.ActivityButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the profile view is clicked.
        /// </summary>
        public Command ProfileCommand
        {
            get
            {
                return this.profileCommand ?? (this.profileCommand = new Command(this.ProfileButtonClicked));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Changes the selection color when an item is tapped.
        /// </summary>
        /// <param name="obj">The object</param>
        private static async void UpdateSelectedItemColor(object obj)
        {
            var grid = obj as Grid;
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            grid.BackgroundColor = (Color)retVal;

            // Makes the selected item color change for 100 milliseconds.
            await Task.Delay(100).ConfigureAwait(true);
            Application.Current.Resources.TryGetValue("Gray-Bg", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }

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
        /// Invoked when the home button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void HomeButtonClicked(object obj)
        {
            UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the interests button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void InterestsButtonClicked(object obj)
        {
            UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the bookmark button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the activity button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ActivityButtonClicked(object obj)
        {
            UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the profile button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ProfileButtonClicked(object obj)
        {
            UpdateSelectedItemColor(obj);
        }

        #endregion
    }
}
