using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for Article profile page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class ProfileViewModel : BaseViewModel
    {
        #region Fields

        private string profileImage;

        private string profileName;

        private string email;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ProfileViewModel" /> class.
        /// </summary>
        public ProfileViewModel()
        {
            this.profileImage = App.BaseImageUrl + "ProfileImage1.png";
            this.profileName = "John Deo";
            this.email = "johndoe@gmail.com";

            this.EditCommand = new Command(this.EditButtonClicked);
            this.NightModeCommand = new Command(this.NightModeOptionClicked);
            this.TextSizeCommand = new Command(this.TextSizeOptionClicked);
            this.SettingsCommand = new Command(this.SettingsOptionClicked);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage
        {
            get
            {
                return this.profileImage;
            }

            set
            {
                if (this.profileImage != value)
                {
                    this.profileImage = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
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
                    this.profileName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
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
                    this.email = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region Command
        /// <summary>
        /// Gets or sets the command that is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the night mode switch is clicked.
        /// </summary>
        public Command NightModeCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the settings option is clicked.
        /// </summary>
        public Command SettingsCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Text size option is clicked.
        /// </summary>
        public Command TextSizeCommand { get; set; }

        #endregion

        #region Methods
        
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
            await Task.Delay(100);
            Application.Current.Resources.TryGetValue("Gray-White", out var retValue);            
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
            await Task.Delay(100);
            Application.Current.Resources.TryGetValue("Gray-White", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }

        #endregion
    }
}
