using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login with social icon page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginWithSocialIconViewModel : LoginViewModel
    {
        #region Fields

        private string password;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="LoginWithSocialIconViewModel" /> class.
        /// </summary>
        public LoginWithSocialIconViewModel()
        {
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.FaceBookLoginCommand = new Command(this.FaceBookClicked);
            this.TwitterLoginCommand = new Command(this.TwitterClicked);
            this.GmailLoginCommand = new Command(this.GmailClicked);
        }

        #endregion

        #region property

        /// <summary>
        /// Gets or sets the property that is bound with an entry that gets the password from user in the login page.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.password = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that is executed when the Log In button is clicked.
        /// </summary>
        public Command LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Sign Up button is clicked.
        /// </summary>
        public Command SignUpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the Forgot Password button is clicked.
        /// </summary>
        public Command ForgotPasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the facebook login button is clicked.
        /// </summary>
        public Command FaceBookLoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the twitter login button is clicked.
        /// </summary>
        public Command TwitterLoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that is executed when the gmail login button is clicked.
        /// </summary>
        public Command GmailLoginCommand { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Invoked when the Log In button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoginClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Sign Up button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SignUpClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Forgot Password button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;
        }

        /// <summary>
        /// Invoked when facebook login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void FaceBookClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when twitter login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void TwitterClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when gmail login button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void GmailClicked(object obj)
        {
            // Do something
        }

        #endregion
    }
}
