using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for profile page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    [DataContract]
    public class ProfileViewModel : BaseViewModel
    {
        #region Fields

        private static ProfileViewModel profileViewModel;

        private string profileImage;

        private string profileName;

        private string email;

        private Command editCommand;

        private Command nightModeCommand;

        private Command textSizeCommand;

        private Command settingsCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ProfileViewModel" /> class.
        /// </summary>
        public ProfileViewModel()
        {
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the value of profile page view model.
        /// </summary>
        public static ProfileViewModel BindingContext =>
            profileViewModel = PopulateData<ProfileViewModel>("profile.json");

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
        /// Gets the command that is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand
        {
            get
            {
                return this.editCommand ?? (this.editCommand = new Command(this.EditButtonClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the night mode switch is clicked.
        /// </summary>
        public Command NightModeCommand
        {
            get
            {
                return this.nightModeCommand ?? (this.nightModeCommand = new Command(this.NightModeOptionClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the settings option is clicked.
        /// </summary>
        public Command SettingsCommand
        {
            get
            {
                return this.settingsCommand ?? (this.settingsCommand = new Command(this.SettingsOptionClicked));
            }
        }

        /// <summary>
        /// Gets the command that is executed when the Text size option is clicked.
        /// </summary>
        public Command TextSizeCommand
        {
            get
            {
                return this.textSizeCommand ?? (this.textSizeCommand = new Command(this.TextSizeOptionClicked));
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
        /// Invoked when the edit button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void EditButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the available status is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void NightModeOptionClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the text size option is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void TextSizeOptionClicked(object obj)
        {
            var grid = obj as Grid;
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            grid.BackgroundColor = (Color)retVal;

            // To make the selected item color changes for 100 milliseconds.
            await Task.Delay(100).ConfigureAwait(true);
            Application.Current.Resources.TryGetValue("Gray-Bg", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }

        /// <summary>
        /// Invoked when the settings option is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void SettingsOptionClicked(object obj)
        {
            var grid = obj as Grid;
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            grid.BackgroundColor = (Color)retVal;

            // To make the selected item color changes for 100 milliseconds.
            await Task.Delay(100).ConfigureAwait(true);
            Application.Current.Resources.TryGetValue("Gray-Bg", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }

        #endregion
    }
}
