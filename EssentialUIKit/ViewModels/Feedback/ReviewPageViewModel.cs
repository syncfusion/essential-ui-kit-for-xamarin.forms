using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.ViewModels.Feedback
{
    /// <summary>
    /// ViewModel for review page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ReviewPageViewModel
    {
        #region Constructor

        public ReviewPageViewModel()
        {
            this.UploadCommand = new Command<object>(this.OnUploadTapped);
            this.SubmitCommand = new Command<object>(this.OnSubmitTapped);
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the value for upload command.
        /// </summary>
        public Command<object> UploadCommand { get; set; }

        /// <summary>
        /// Gets or sets the value for submit command.
        /// </summary>
        public Command<object> SubmitCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Upload button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnUploadTapped(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the Submit button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void OnSubmitTapped(object obj)
        {
            // Do something
        }

        #endregion
    }
}
