using Syncfusion.XForms.Buttons;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using ProfileModel = EssentialUIKit.Models.Profile;

namespace EssentialUIKit.ViewModels.Detail
{
    /// <summary>
    /// ViewModel for event detail page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class EventDetailViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<ProfileModel> connnections;

        private string headerImagePath;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="EventDetailViewModel" /> class.
        /// </summary>
        public EventDetailViewModel()
        {
            this.HeaderImagePath = "Event-Image-two.png";

            this.Connections = new ObservableCollection<ProfileModel>()
            {
                 new ProfileModel { ImagePath = "ProfileImage7.png" },
                 new ProfileModel { ImagePath = "ProfileImage9.png" },
                 new ProfileModel { ImagePath = "ProfileImage10.png" },
                 new ProfileModel { ImagePath = "ProfileImage11.png" },
                 new ProfileModel { ImagePath = "ProfileImage7.png" },
                 new ProfileModel { ImagePath = "ProfileImage9.png" },
                 new ProfileModel { ImagePath = "ProfileImage7.png" },
                 new ProfileModel { ImagePath = "ProfileImage9.png" },
                 new ProfileModel { ImagePath = "ProfileImage10.png" },
                 new ProfileModel { ImagePath = "ProfileImage11.png" },
                 new ProfileModel { ImagePath = "ProfileImage7.png" },
                 new ProfileModel { ImagePath = "ProfileImage9.png" },
                 new ProfileModel { ImagePath = "ProfileImage7.png" },
                 new ProfileModel { ImagePath = "ProfileImage9.png" },
                 new ProfileModel { ImagePath = "ProfileImage10.png" },
                 new ProfileModel { ImagePath = "ProfileImage11.png" }
            };

            this.FavouriteCommand = new Command(this.FavouriteButtonClicked);
            this.JoinCommand = new Command(this.JoinButtonClicked);
            this.MenuCommand = new Command(this.MenuButtonClicked);
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the header image path.
        /// </summary>
        public string HeaderImagePath
        {
            get { return App.BaseImageUrl + this.headerImagePath; }
            set { this.headerImagePath = value; }
        }

        /// <summary>
        /// Gets or sets the profile image collection.
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

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the join button is clicked.
        /// </summary>
        public Command JoinCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            var button = obj as SfButton;

            if (button == null)
            {
                return;
            }

            if (button.Text == "\ue701")
            {
                button.Text = "\ue732";
                Application.Current.Resources.TryGetValue("PrimaryColor", out var retVal);
                button.TextColor = (Color)retVal;
            }
            else
            {
                button.Text = "\ue701";
                Application.Current.Resources.TryGetValue("Gray-600", out var retVal);
                button.TextColor = (Color)retVal;
            }
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuButtonClicked(object obj)
        {
            //Do something
        }

        /// <summary>
        /// Invoked when the join button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void JoinButtonClicked(object obj)
        {
            //Do something
        }

        #endregion
    }
}
