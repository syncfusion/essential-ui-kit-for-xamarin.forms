using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Navigation
{
    /// <summary>
    /// Viewmodel of settings page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SettingsViewModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EssentialUIKit.ViewModels.Navigation.SettingsViewModel"/> class.
        /// </summary>
        public SettingsViewModel()
        {
            this.DownloadCommand = new Command(this.DownloadQualityTapped);
            this.ShowFilesCommand = new Command(this.ShowHiddenFilesTapped);
            this.PolicyCommand = new Command(this.PrivacyPolicyTapped);
        }

        /// <summary>
        /// Gets or sets the value of command used for download quality click.
        /// </summary>
        public Command DownloadCommand { get; set; }

        /// <summary>
        /// Gets or sets the value of command used for show hidden files click.
        /// </summary>
        public Command ShowFilesCommand { get; set; }

        /// <summary>
        /// Gets or sets the value of command used for privacy policy click.
        /// </summary>
        public Command PolicyCommand { get; set; }

        /// <summary>
        /// Invoked when download quality tapped.
        /// </summary>
        /// <param name="obj">The Object.</param>
        private void DownloadQualityTapped(object obj)
        {
        }

        /// <summary>
        /// Invoked when Show hidden files tapped.
        /// </summary>
        /// <param name="obj">The Object.</param>
        private void ShowHiddenFilesTapped(object obj)
        {
        }

        /// <summary>
        /// Invoked when Privacy policy tapped.
        /// </summary>
        /// <param name="obj">The Object.</param>
        private void PrivacyPolicyTapped(object obj)
        {
        }
    }
}
