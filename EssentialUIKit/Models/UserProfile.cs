using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models
{
    /// <summary>
    /// Model for SocialProfile
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class UserProfile
    {
        #region Fields

        private string imagePath;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        [DataMember(Name = "imagePath")]
        public string ImagePath
        {
            get { return App.ImageServerPath + this.imagePath; }
            set { this.imagePath = value; }
        }

        #endregion
    }
}