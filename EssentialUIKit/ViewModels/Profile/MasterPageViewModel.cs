using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for burger menu expand page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class MasterPageViewModel : BaseViewModel
    {
        #region Fields

        private string profileName;

        private string profileImage;

        private string email;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MasterPageViewModel" /> class.
        /// </summary>
        public MasterPageViewModel()
        {
            this.profileName = "John Doe";
            this.profileImage = App.BaseImageUrl + "ProfileImage1.png";
            this.email = "johndoe@gmail.com";

            this.HomeCommand = new Command(this.HomeButtonClicked);
            this.InterestsCommand = new Command(this.InterestsButtonClicked);
            this.BookmarkCommand = new Command(this.BookmarkButtonClicked);
            this.ActivityCommand = new Command(this.ActivityButtonClicked);
            this.ProfileCommand = new Command(this.ProfileButtonClicked);
        }

        #endregion

        #region Public properties

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
        /// Gets or sets the command that is executed when the home view is clicked.
        /// </summary>
        public Command HomeCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the interests view is clicked.
        /// </summary>
        public Command InterestsCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the bookmark view is clicked.
        /// </summary>
        public Command BookmarkCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the activity view is clicked.
        /// </summary>
        public Command ActivityCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the profile view is clicked.
        /// </summary>
        public Command ProfileCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the home button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void HomeButtonClicked(object obj)
        {
            this.UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the interests button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void InterestsButtonClicked(object obj)
        {
            this.UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the bookmark button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            this.UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the activity button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ActivityButtonClicked(object obj)
        {
            this.UpdateSelectedItemColor(obj);
        }

        /// <summary>
        /// Invoked when the profile button is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ProfileButtonClicked(object obj)
        {
            this.UpdateSelectedItemColor(obj);
        }
      
        /// <summary>
        /// Changes the selection color when an item is tapped.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void UpdateSelectedItemColor(object obj)
        {
            var grid = obj as Grid;
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            grid.BackgroundColor = (Color)retVal;

            // Makes the selected item color change for 100 milliseconds.
            await Task.Delay(100);
            Application.Current.Resources.TryGetValue("Gray-White", out var retValue);
            grid.BackgroundColor = (Color)retValue;
        }

        #endregion
    }
}
