using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace EssentialUIKit.Models.Navigation
{
    /// <summary>
    /// Model for Album list.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Album
    {
        private string albumImage;

        /// <summary>
        /// Gets or sets the album name.
        /// </summary>
        [DataMember(Name = "albumName")]
        public string AlbumName { get; set; }

        /// <summary>
        /// Gets or sets the album image.
        /// </summary>
        [DataMember(Name = "albumImage")]
        public string AlbumImage
        {
            get
            {
                return App.ImageServerPath + this.albumImage;
            }

            set
            {
                this.albumImage = value;
            }
        }

        /// <summary>
        /// Gets the total photos.
        /// </summary>
        [DataMember(Name = "imagesCount")]
        public string ImagesCount { get; internal set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [DataMember(Name = "category")]
        public string Category { get; set; }
    }
}
