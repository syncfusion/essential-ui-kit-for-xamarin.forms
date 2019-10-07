using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Profile
{
    /// <summary>
    /// ViewModel for profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ChatProfileViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ProfileViewModel" /> class
        /// </summary>
        public ChatProfileViewModel()
        {
            this.EditCommand = new Command(this.EditButtonClicked);
            this.AvailableCommand = new Command(this.AvailableStatusClicked);
            this.NotificationCommand = new Command(this.NotificationOptionClicked);
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the edit button is clicked.
        /// </summary>
        public Command EditCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the available status is clicked.
        /// </summary>
        public Command AvailableCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the notification option is clicked.
        /// </summary>
        public Command NotificationCommand { get; set; }

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
        private async void AvailableStatusClicked(object obj)
        {
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            (obj as Grid).BackgroundColor = (Color)retVal;
            await Task.Delay(100);
            (obj as Grid).BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when the notification option is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void NotificationOptionClicked(object obj)
        {
            Application.Current.Resources.TryGetValue("Gray-100", out var retVal);
            (obj as Grid).BackgroundColor = (Color)retVal;
            await Task.Delay(100);
            (obj as Grid).BackgroundColor = Color.Transparent;
        }

        #endregion
    }
}
