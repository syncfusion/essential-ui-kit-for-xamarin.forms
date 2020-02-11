using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the app usage list page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class AppUsage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the app.
        /// </summary>
        [DataMember(Name = "appName")]
        public string AppName { get; set; }

        /// <summary>
        /// Gets or sets the progress bar value.
        /// </summary>
        [DataMember(Name = "progressBarValue")]
        public string ProgressBarValue { get; set; }

        /// <summary>
        /// Gets or sets the progress value.
        /// </summary>
        [DataMember(Name = "progressValue")]
        public string ProgressValue { get; set; }

        /// <summary>
        /// Gets or sets the background color for the app within the circular border.
        /// </summary>
        [DataMember(Name = "backgroundColor")]
        public string BackgroundColor { get; set; }

        #endregion
    }
}