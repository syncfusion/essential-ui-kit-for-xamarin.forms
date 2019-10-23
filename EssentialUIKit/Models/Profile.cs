using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    /// <summary>
    /// Model for SocialProfile
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Profile
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the imagepath.
        /// </summary>
        public string ImagePath { get; set; }

        #endregion
    }
}
